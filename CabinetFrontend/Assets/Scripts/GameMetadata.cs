using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMetadata : MonoBehaviour {

	//Game folder name
	public string GameFolderPath;

	//The following public members are all metadata entries and their defaults.
	public string GameName = "No Title";
	public string[] Author = {"No authors."};
	public string Description = "No description.";

	public string ExeFolder = "";
	public string ExeName = "game.exe";
	public string ScreenshotFolder = "";

	public string KeyW;
	public string KeyA;
	public string KeyS;
	public string KeyD;

	public string Key1;
	public string Key2;
	public string Key3;
	public string KeyZ;
	public string KeyX;
	public string KeyC;
	public string Key5;

	public string KeyI;
	public string KeyJ;
	public string KeyK;
	public string KeyL;

	public string Key7;
	public string Key8;
	public string Key9;
	public string KeyB;
	public string KeyN;
	public string KeyM;
	public string Key6;


	public void loadFromJson(string localFolderPath) {
		string thisJson = System.IO.File.ReadAllText (localFolderPath + "\\metadata.json");
		JsonUtility.FromJsonOverwrite (thisJson, this);
		GameFolderPath = localFolderPath;
	}
}
