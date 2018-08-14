using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using SimplePopup;


public class ShareImageCanvas : MonoBehaviour {
	// public
	// private
	private bool isProcessing = false;
	/*public Image buttonShare;
		public Image buttonShare2;
	public Image buttonShare3;
	public Image buttonShare4;
	public Image buttonShare5; */
	public string mensaje;

	public GameObject canvasUI;

	void Update () {

		if (Input.GetKeyUp (KeyCode.Escape)) {
			SimplePopupManager.Instance.CreatePopup ("Are you sure want to quit?");
			SimplePopupManager.Instance.AddButton ("Yes", delegate {
				Application.Quit ();
			});
			SimplePopupManager.Instance.AddButton ("No", delegate {
				SimplePopupManager.Instance.HidePopup ();
			});
			SimplePopupManager.Instance.ShowPopup ();
		}
	}

	//function called from a button
	public void ButtonShare ()
	{
		/*buttonShare.enabled = false;
		buttonShare2.enabled = false;
		buttonShare3.enabled = false;
		buttonShare4.enabled = false;
		buttonShare5.enabled = false;*/
		canvasUI.SetActive (false);

		if(!isProcessing){
			StartCoroutine( ShareScreenshot() );
		}
	}
	public IEnumerator ShareScreenshot()
	{
		isProcessing = true;
		// wait for graphics to render
		yield return new WaitForEndOfFrame();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		// create the texture
		Texture2D screenTexture = new Texture2D(Screen.width, Screen.height,TextureFormat.RGB24,true);
		// put buffer into texture
		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
		// apply
		screenTexture.Apply();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		byte[] dataToSave = screenTexture.EncodeToPNG();
				string myFilename =  System.DateTime.Now.ToString("DWH_HHmmss") + ".jpg";
				 string myDefaultLocation = Application.persistentDataPath + "/" + myFilename;
		   string myFolderLocation = "/storage/emulated/0/DCIM/DWHCiptaKarya/";
         string myScreenshotLocation = myFolderLocation + myFilename;

            //ENSURE THAT FOLDER LOCATION EXISTS
         if(!System.IO.Directory.Exists(myFolderLocation)){
             System.IO.Directory.CreateDirectory(myFolderLocation);
         }
 
		 //TAKE THE SCREENSHOT AND AUTOMATICALLY SAVE IT TO THE DEFAULT LOCATION.
         Application.CaptureScreenshot(myFilename);


		File.WriteAllBytes(myScreenshotLocation, dataToSave);
		if(!Application.isEditor)
		{
			// block to open the file and share it ------------START
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + myScreenshotLocation);
			  
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

			intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), ""+ mensaje);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");

			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

			currentActivity.Call("startActivity", intentObject);
		}

		isProcessing = false;

		canvasUI.SetActive (true);
		/*buttonShare.enabled = true;
		buttonShare2.enabled = true;
		buttonShare3.enabled = true;
		buttonShare4.enabled = true;
		buttonShare5.enabled = true;*/
	}
}