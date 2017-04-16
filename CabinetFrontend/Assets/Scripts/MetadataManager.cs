using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MetadataManager : MonoBehaviour {

	public Transform content;
	string PathToGames;

	[SerializeField]
	private GameObject _listPanelPrefab;

	// Use this for initialization
	void Start () {
		PathToGames = Application.dataPath.Replace ('/', '\\') + "\\Games";
		string[] gameFolders = Directory.GetDirectories (PathToGames);
		foreach (string folderPath in gameFolders) {
			string metaFilePath = folderPath + "\\metadata.json";
			if (File.Exists(metaFilePath)) {
				GameObject GameListPanel = Instantiate (_listPanelPrefab, content);
				GameListPanel.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				GameObject GameListMetadata = GameListPanel.transform.Find ("Metadata").gameObject;
				GameObject GameListText = GameListPanel.transform.Find ("Text").gameObject;
				GameObject GameLisImage = GameListPanel.transform.Find ("Image").gameObject;
				GameMetadata newMetadata = GameListMetadata.GetComponent<GameMetadata> ();
				newMetadata.loadFromJson(folderPath);
				GameListPanel.name = newMetadata.GameName;
				GameListText.GetComponent<UnityEngine.UI.Text> ().text = newMetadata.GameName;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
