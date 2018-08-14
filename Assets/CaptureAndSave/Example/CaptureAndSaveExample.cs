using UnityEngine;
using System.Collections;

public class CaptureAndSaveExample : MonoBehaviour {
	
	string x = "0";
	string y = "0";
	string width = "0";
	string height = "0";
	string path="/storage/emulated/0/DCIM/Pocka4D/";
	public Texture2D tex;

	CaptureAndSave snapShot ;

	void Start()
	{
		snapShot = GameObject.FindObjectOfType<CaptureAndSave>();
	}

	void OnEnable()
	{
		CaptureAndSaveEventListener.onError += OnError;
		CaptureAndSaveEventListener.onSuccess += OnSuccess;
	}

	void OnDisable()
	{
		CaptureAndSaveEventListener.onError += OnError;
		CaptureAndSaveEventListener.onSuccess += OnSuccess;
	}

	void OnError(string error)
	{
		Debug.Log ("Error : "+error);
	}

	void OnSuccess(string msg)
	{
		Debug.Log ("Success : "+msg);
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(20,20,150,50),"Save Full Screen"))
		{
			snapShot.CaptureAndSaveToAlbum(); 
			snapShot.CaptureAndSaveAtPath(path);
		}

		
	}
}
