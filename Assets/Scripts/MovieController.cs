using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using RenderHeads.Media.AVProVideo;

public class MovieController : MonoBehaviour {
	private static string Folder = "VRFiles/";
	private static string StartVideoID = "vr_1";

	private const int BUTTON_WIDTH = 100;
	private const int BUTTON_HEIGHT = 50;

	private string answerA = "A";
	private string answerB = "B";
	private string answerC = "C";

	private Google2u.Movie _Movie;
	private Google2u.Answer _Answer;
	private Google2u.MovieRow _currMovieRow;

	public MediaPlayer playingMovie;

	private bool showAnswer = false;
	private List<string> answerIDList = new List<string>();

	// Use this for initialization
	void Start () {
		_Movie = GetComponent<Google2u.Movie> ();
		_Answer = GetComponent<Google2u.Answer> ();

		_currMovieRow = _Movie.GetRow (StartVideoID);

		// attach event function
		playingMovie.Events.AddListener(OnVideoEvent);

		PlayVideo (_currMovieRow._FileName);
	}

	private void PlayVideo(string fileName) {
		Debug.Log(string.Format("PlayMovie: {0}", fileName));
			
		string filePath = Folder + fileName;

		playingMovie.m_AutoStart = true;
		playingMovie.OpenVideoFromFile (MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, filePath);
	}

	private void NextVideo() {
		if (_currMovieRow._NextIDList.Count <= 0) {
			Debug.Log("Game End");
		} else if (_currMovieRow._NextIDList.Count == 1) {
			if (showAnswer == true)
				showAnswer = false;
			
			_currMovieRow = _Movie.GetRow (_currMovieRow._NextIDList[0]);

			PlayVideo(_currMovieRow._FileName);
		} else {
			showAnswer = true;

			if (_currMovieRow._NextIDList.Count < 3) {
				SetAnswerText(answerA, _currMovieRow._AnswerIDList [0]);
				SetAnswerText(answerB, _currMovieRow._AnswerIDList [1]);
			} else {
				
			}
		}
	}

	private void SetAnswerText(string btnText, string answerID) {
		Google2u.AnswerRow rowAnswer = _Answer.GetRow (answerID);
		btnText = rowAnswer._Answer;
	}

	// Callback function to handel events
	public void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode) {
		switch (et) {
		case MediaPlayerEvent.EventType.ReadyToPlay:
			mp.Control.Play ();
			break;

		case MediaPlayerEvent.EventType.FirstFrameReady:
			Debug.Log ("Firt frame ready");
			break;

		case MediaPlayerEvent.EventType.FinishedPlaying:
			Debug.Log ("Finished playing");
			NextVideo ();
			break;
		}
	}

	void OnGUI() {
		if (showAnswer) {
			int buttonY = Screen.height - (BUTTON_HEIGHT * 2);

			if (_currMovieRow._NextIDList.Count < 3) {
				if (GUI.Button(new Rect(BUTTON_WIDTH, buttonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerA)) {
					Debug.Log ("AnswerA");
				}

				if (GUI.Button(new Rect(Screen.width - (BUTTON_WIDTH * 2), buttonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerB)) {
					Debug.Log ("AnswerB");
				}
			} else {
				if (GUI.Button(new Rect(BUTTON_WIDTH, buttonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerA)) {
					Debug.Log ("AnswerA");
				}

				if (GUI.Button (new Rect (Screen.width - (BUTTON_WIDTH / 2), buttonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerB)) {
					Debug.Log ("AnswerB");
				}

				if (GUI.Button(new Rect(Screen.width - (BUTTON_WIDTH * 2), buttonY, BUTTON_WIDTH, BUTTON_HEIGHT), answerC)) {
					Debug.Log ("AnswerC");
				}
			}
		}
	}

	// Answer class
	class AnswerData {
		public string text;
		public string next_id;

		public string Answer { get { return text; } set { text = value; } }
		public string NextID { get { return next_id; } set { next_id = value; } }
	}

	class MovieData {
		public List<string> nextIDList = new List<string> ();
		public List<AnswerData> answerList = new List<AnswerData> ();
	}

	private void LoadTable() {
		Google2u.Movie movie = GetComponent<Google2u.Movie> ();
		Google2u.Answer answer = GetComponent<Google2u.Answer> ();

		foreach (Google2u.MovieRow row in movie.Rows) {
		}
	}
}
