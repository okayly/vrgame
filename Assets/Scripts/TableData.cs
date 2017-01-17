using UnityEngine;
using System.Collections;

public class TableData : MonoBehaviour {
	private static string VR = "vr_";
	
	private Google2u.Movie _Movie;
	private Google2u.Answer _Answer;

	// Use this for initialization
	void Start () {
		_Movie = GetComponent<Google2u.Movie> ();
		_Answer = GetComponent<Google2u.Answer> ();

		Google2u.MovieRow moveRow = _Movie.GetRow ("vr_1");
		Debug.Log(string.Format("MovieID:{0}", moveRow._MovieID));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
