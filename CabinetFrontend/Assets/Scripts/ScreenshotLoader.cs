using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
public class ScreenshotLoader : MonoBehaviour {
	public RawImage screenshotPanel;
	public List<Texture2D> Textures;
	public Texture2D PlaceholderTexture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	public Texture2D GetTexture() {
		return Textures[0];
	}

	public void LoadAllScreenshots (string path) {
		Textures.Clear ();
		DirectoryInfo dir = new DirectoryInfo (path);
		if (dir.Exists) {
			FileInfo[] allImageInfo = dir.GetFiles ("*.*");
			foreach (FileInfo imageInfo in allImageInfo) {
				if (!imageInfo.Name.Contains (".meta")) {
					Textures.Add(LoadPNG(imageInfo.FullName));
				}
			}
		}
		print (Textures.Count);
		if (Textures.Count == 0) {
			Textures.Add (PlaceholderTexture);
		}
	}

	public static Texture2D LoadPNG(string filePath) {
		Texture2D tex = null;
		byte[] fileData;
		fileData = File.ReadAllBytes(filePath);
		tex = new Texture2D (2, 2, TextureFormat.BGRA32,false);
		tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		return tex;
	}
}
