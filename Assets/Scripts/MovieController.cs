using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using RenderHeads.Media.AVProVideo;

public class MovieController : MonoBehaviour {
	private static string Folder = "VRFiles/";

	private Rect button = new Rect ( 0, 0, 500, 50 );
	private int buttonGapH = 10;

	// GUI Button Text
	private string[] answerText = new string[ 3 ];

	public string this [int i] { get { return answerText [i]; } set { answerText [i] = value; } }

	public MediaPlayer playingMovie;
	private TableData tableData;

	public int currSceneID = 1;
	private bool showAnswer = false;

	private enum State {
		Loading,
		Playing,
		Finished,
	}

//	private State _state = State.Loading;

	// Use this for initialization
	void Start () {
		// Table Data
		tableData = GetComponent<TableData> ();

		// attach event function - Move to Editor
		playingMovie.Events.AddListener(OnVideoEvent);

		// Play first video
		PlayVideo ();
	}

	private void PlayVideo() {
		string fileName = tableData.movieMap [currSceneID].FileName;
		Debug.Log(string.Format("currSceneID: {0}, fileName: {1}", currSceneID, fileName));
			
		string filePath = Folder + fileName;
		playingMovie.OpenVideoFromFile (MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, filePath, false);
	}

	// Callback function to handel events
	public void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode) {
		switch (et) {
		case MediaPlayerEvent.EventType.ReadyToPlay:
			Debug.Log (string.Format ("MediaPlayerEvent.EventType.ReadyToPlay: {0}", playingMovie.m_VideoPath));
			mp.Control.Play ();
			break;

		case MediaPlayerEvent.EventType.FirstFrameReady:
			Debug.Log ("Firt frame ready");
			break;

		case MediaPlayerEvent.EventType.FinishedPlaying:
			{
				Debug.Log (string.Format("MediaPlayerEvent.EventType.FinishedPlaying: {0}", tableData.movieMap [currSceneID].SceneType));
				if (tableData.movieMap [currSceneID].SceneType == "talk" || tableData.movieMap [currSceneID].SceneType == "answer") {
					currSceneID = tableData.movieMap [currSceneID].nextList [0].NextID;
					PlayVideo ();

				} else {
					// Set answer position
					button.x = (Screen.width - button.width) / 2;
					button.y = Screen.height - ( (button.height + buttonGapH) * tableData.movieMap[currSceneID].nextList.Count );

					// Set answer text
					int buttonID = 0;
					foreach (TableData.NextData nextData in tableData.movieMap[currSceneID].nextList) {
						answerText [buttonID] = nextData.Answer;
						buttonID++;
					}

					showAnswer = true;
				}

			}
			break;

		case MediaPlayerEvent.EventType.Error:
			Debug.Log ("ErrorCode: " + errorCode);
			break;
		}
	}

	void OnGUI() {
		if (showAnswer) {
			switch (tableData.movieMap [currSceneID].nextList.Count) {
			case 2:
				ShowTwoAnswer ();
				break;
			case 3:				
				ShowThreeAnswer ();
				break;
			}
		}
	}

	private void SelectAnswer(int answerID) {
		if ( answerID >= 0 && answerID < 3 ) {
			currSceneID = tableData.movieMap [currSceneID].nextList [answerID].NextID;
			PlayVideo ();
			showAnswer = false;

			Debug.Log (string.Format ("AnswerA currSceneID: {0}, fineName: {1}", currSceneID, tableData.movieMap [currSceneID].FileName));
		}
	}

	private void ShowTwoAnswer() {
		if (GUI.Button(new Rect(button.x, button.y, button.width, button.height), answerText[0])) {
			SelectAnswer (0);
		}

		if (GUI.Button(new Rect(button.x, button.y + (button.height + buttonGapH), button.width, button.height), answerText[1])) {
			SelectAnswer (1);
		}
	}

	private void ShowThreeAnswer() {
		if (GUI.Button(new Rect(button.x, button.y, button.width, button.height), answerText[0])) {
			SelectAnswer (0);
		}

		if (GUI.Button(new Rect(button.x, button.y + (button.height + buttonGapH), button.width, button.height), answerText[1])) {
			SelectAnswer (1);
		}

		if (GUI.Button(new Rect(button.x, button.y + (button.height + buttonGapH) * 2, button.width, button.height), answerText[2])) {
			SelectAnswer (2);
		}
	}

	//	void LateUpdate(){
	//		if (_state == State.Loading) {
	////			Debug.Log (string.Format ("state: {0}", _state));
	//
	//			// Finsished Loading
	//			if (IsVideoLoaded (playingMovie)) {
	//				Debug.Log ("Movie Play");
	//				playingMovie.Play ();
	//
	//				_state = State.Playing;
	//			}
	//		} else if (_state == State.Finished) {
	//			Debug.Log ("Do Something");
	//		}
	//	}
	//
	//	private static bool IsVideoLoaded(MediaPlayer player) {
	//		return (player != null && player.Control != null && player.Control.HasMetaData () && player.Control.CanPlay () && player.TextureProducer.GetTextureFrameCount () > 0);
	//	}
}
