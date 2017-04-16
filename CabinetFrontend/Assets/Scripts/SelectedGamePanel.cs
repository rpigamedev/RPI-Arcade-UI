using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		Text descriptionText = Description.GetComponent<Text> ();
		descriptionText.text = currentMetadata.Description;
		//Append the authors
		descriptionText.text += "\n\n<b>Game developed by:</b>\n";
		foreach (string authorName in currentMetadata.Author) {
			descriptionText.text += "\t" + authorName + "\n";
		}
		//Grab screenshots
		GameObject ScreenshotLoaderObj = transform.Find ("ScreenshotLoader").gameObject;
		ScreenshotLoader screen = ScreenshotLoaderObj.GetComponent<ScreenshotLoader> ();
		screen.LoadAllScreenshots (newMetadata.GameFolderPath + "\\" + newMetadata.ScreenshotFolder);
		GameObject Screenshot = transform.Find ("Screenshot").gameObject;
		Screenshot.GetComponent<UnityEngine.UI.RawImage> ().texture = null;
		Screenshot.GetComponent<UnityEngine.UI.RawImage> ().texture = screen.GetTexture ();
	}

	public void LaunchCurrentGame () {
		Debug.Log ("Launching game: " + currentMetadata.GameName);
		gameLaunch.launchGameShim (currentMetadata.GameFolderPath + currentMetadata.ExeFolder, currentMetadata.ExeName, "");
		Debug.Log ("Game ended: " + currentMetadata.GameName);
	}

	// Use this for initialization
	void Start () {
		gameLaunch = GetComponent<LaunchExternalProgram> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
