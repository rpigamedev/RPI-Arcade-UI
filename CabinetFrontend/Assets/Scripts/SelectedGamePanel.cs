using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGamePanel : MonoBehaviour {

	private LaunchExternalProgram gameLaunch;
	private GameMetadata currentMetadata;

	public void UpdateDisplayData (GameMetadata newMetadata) {
		currentMetadata = newMetadata;
		//Update title
		GameObject Title = transform.Find ("Title").gameObject;
		Title.GetComponent<UnityEngine.UI.Text> ().text = newMetadata.GameName;
		//Update description
		GameObject Description = transform.Find ("Description").gameObject;
		Description.GetComponent<UnityEngine.UI.Text> ().text = newMetadata.Description;
		//Grab screenshots
		GameObject ScreenshotLoaderObj = transform.Find ("ScreenshotLoader").gameObject;
		ScreenshotLoader screen = ScreenshotLoaderObj.GetComponent<ScreenshotLoader> ();
		screen.LoadAllScreenshots (newMetadata.GameFolderPath + "\\" + newMetadata.ScreenshotFolder);
		GameObject Screenshot = transform.Find ("Screenshot").gameObject;
		Screenshot.GetComponent<UnityEngine.UI.RawImage> ().texture = screen.GetTexture ();
	}

	public void LaunchCurrentGame () {
		gameLaunch.launchGameShim (currentMetadata.GameFolderPath + "\\" + currentMetadata.ExeFolder, currentMetadata.ExeName, "");
	}

	// Use this for initialization
	void Start () {
		gameLaunch = GetComponent<LaunchExternalProgram> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
