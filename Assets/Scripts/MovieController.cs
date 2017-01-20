using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using RenderHeads.Media.AVProVideo;

public class MovieController : MonoBehaviour {
	private static string Folder = "VRFiles/";

	private const int BUTTON_WIDTH = 200;
	private const int BUTTON_HEIGHT = 100;
	private int ButtonY = 0;

	// GUI Button Text
	private string[] answerText = new string[ 3 ];

	public string this [int i] { get { return answerText [i]; } set { answerText [i] = value; } }

	public MediaPlayer playingMovie;
	private TableData tableData;

	private int currID = 10;
	private bool showAnswer = false;

	// Use this for initialization
	void Start () {
		// Answer Button Position Y
		ButtonY = Screen.height - (BUTTON_HEIGHT * 2);

		// Table Data
		tableData = GetComponent<TableData> ();

		// attach event function
		playingMovie.Events.AddListener(OnVideoEvent);

		// Play first video
		PlayVideo (tableData.movieList[currID].FileName);
	}

	private void PlayVideo(string fileName) {
		Debug.Log(string.Format("PlayMovie: {0}", fileName));
			
		string filePath = Folder + fileName;

		playingMovie.m_AutoStart = true;
		playingMovie.OpenVideoFromFile (MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, filePath);
	}

	private void NextVideo() {
		int nextID = ++currID;
		PlayVideo (tableData.movieList [nextID].FileName);
//		Debug.Log(string.Format("{0} Next fileName: {1}", nextID, tableData.movieList [nextID].FileName));
	}

	// Callback function to handel events
	public void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode) {
		switch (et) {
		case MediaPlayerEvent.EventType.ReadyToPlay:
//			mp.Control.Play ();
			break;

		case MediaPlayerEvent.EventType.FirstFrameReady:
			Debug.Log ("Firt frame ready");
			break;

		case MediaPlayerEvent.EventType.FinishedPlaying:
			{
				Debug.Log ("Finished playing");

				if (tableData.movieList [currID].SceneType == "talk" || tableData.movieList [currID].SceneType == "answer") {
					Debug.Log ("Talk");
					NextVideo ();
				} else {
					Debug.Log ("Question");

					// Set answer text
					int buttonID = 0;
					foreach (TableData.NextData nextData in tableData.movieList[currID].nextList) {
						answerText [buttonID] = nextData.Answer;
						buttonID++;
					}

					showAnswer = true;
				}
				break;
			}
		}
	}

	private void ShowTwoAnswer() {
		if (GUI.Button(new Rect(BUTTON_WIDTH, ButtonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerText[0])) {
			Debug.Log ("AnswerA");

			currID = tableData.movieList [currID].nextList [0].NextID;
			Debug.Log (string.Format ("AnswerA currID: {0}", currID));
			PlayVideo (tableData.movieList [currID].FileName);
		}

		if (GUI.Button(new Rect(Screen.width - (BUTTON_WIDTH * 2), ButtonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerText[1])) {
			Debug.Log ("AnswerB");

			currID = tableData.movieList [currID].nextList [1].NextID;
			Debug.Log (string.Format ("AnswerB currID: {0}", currID));
			PlayVideo (tableData.movieList [currID].FileName);
		}
	}

	private void ShowThreeAnswer() {
		if (GUI.Button(new Rect(BUTTON_WIDTH, ButtonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerText[0])) {
			Debug.Log ("AnswerA");
		}

		if (GUI.Button (new Rect (Screen.width - (BUTTON_WIDTH / 2), ButtonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerText[1])) {
			Debug.Log ("AnswerB");
		}

		if (GUI.Button(new Rect(Screen.width - (BUTTON_WIDTH * 2), ButtonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerText[2])) {
			Debug.Log ("AnswerC");
		}
	}

	void OnGUI() {
		if (showAnswer) {
			switch (tableData.movieList [currID].nextList.Count) {
			case 2:
				ShowTwoAnswer ();
				break;
			case 3:				
				ShowThreeAnswer ();
				break;
			}
		}
	}
}
