using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TableData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadTable ();
	}

	// NextData
	public class NextData {
		private int next_id;
		private string answer;

		public int NextID { get { return next_id; } set { next_id = value; } }
		public string Answer { get { return answer; } set { answer = value; } }
	}

	public class MovieData {
		private int scene_id;
		private string fileName;
		private string scene_type;

		public int SceneID { get { return scene_id; } set { scene_id = value; } }
		public string SceneType { get { return scene_type; } set { scene_type = value; } }
		public string FileName { get { return fileName; } set { fileName = value; } }

		public List<NextData> nextList = new List<NextData> ();
	}

	public List<MovieData> movieList = new List<MovieData>();

	private void LoadTable() {
		Google2u.BT_MOVIE btMovie = GetComponent<Google2u.BT_MOVIE> ();
		Google2u.BT_ANSWER btAnswer = GetComponent<Google2u.BT_ANSWER> ();

		foreach (Google2u.BT_MOVIERow movieRow in btMovie.Rows) {
			MovieData movieData = new MovieData ();
			movieData.SceneID = movieRow._SceneID;
			movieData.FileName = movieRow._FileName;
			movieData.SceneType = movieRow._SceneType;


			for (int cnt = 0; cnt < movieRow._NextIDList.Count; ++cnt) {
				int nextID = movieRow._NextIDList [cnt];

				// set next id
				NextData nextData = new NextData ();
				nextData.NextID = nextID;

				// set answer text
				if (movieRow._SceneType == "question") {
					int answerID = movieRow._AnswerIDList [cnt];

					foreach (Google2u.BT_ANSWERRow answerRow in btAnswer.Rows) {
						if (answerRow._AnswerID == answerID) {
							nextData.Answer = answerRow._Answer;
						}
					}
				}

				movieData.nextList.Add (nextData);
			}

			movieList.Add (movieData);
		}
	}
}
