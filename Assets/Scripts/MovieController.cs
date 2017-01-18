using UnityEngine;
using System.Collections;
using RenderHeads.Media.AVProVideo;

public class MovieController : MonoBehaviour {
	private static string Folder = "VRFiles/";
	private static string VR = "vr_";
	private int videoNumber = 1;

	private Google2u.Movie _Movie;
	private Google2u.Answer _Answer;

	public MediaPlayer videoPlayer;

	// Use this for initialization
	void Start () {
		_Movie = GetComponent<Google2u.Movie> ();
		_Answer = GetComponent<Google2u.Answer> ();

		Google2u.MovieRow moveRow = _Movie.GetRow (VR + videoNumber.ToString());
		NewVideo (Folder + moveRow._FileName);

//		Debug.Log(string.Format("MovieID:{0}", moveRow._MovieID));	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewVideo(string filePath) {
		
		videoPlayer.m_AutoStart = true;
		videoPlayer.OpenVideoFromFile (MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, filePath, true);
	}
}
