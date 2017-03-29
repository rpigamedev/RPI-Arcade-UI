using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
public class ContentLoader : MonoBehaviour {
	public RawImage mainImage;
	public TextAsset imageAsset;
	Texture2D theTex;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/images");
		FileInfo[] info = dir.GetFiles("*.*");
		Debug.Log (info[0].DirectoryName);
		//byte[] bytes = ReadImageFile("C:\\Users\\zucken\\Desktop\\images");

		//Texture tex;
		//Texture2D tex = new Texture2D (2, 2, TextureFormat.BGRA32,false);
		//tex.LoadImage(bytes);
		theTex = LoadPNG (info[0].FullName);
		mainImage.texture=theTex;
		//mainImage.sprite =Sprite.Create(theTex ,mainImage.gameObject.GetComponent<RectTransform>().rect,mainImage.gameObject.GetComponent<RectTransform>().pivot);
	
	
		//	byte[] imageData = null;
		//FileInfo fileInfo = info[0];
		//	long imageFileLength = fileInfo.Length;
		//FileStream fs = new FileStream(fileInfo.DirectoryName, FileMode.Open, FileAccess.Read);

	}

	public static Texture2D LoadPNG(string filePath) {

		Texture2D tex = null;
		byte[] fileData;

		//if (File.Exists(filePath))     {
			Debug.Log ("exists");
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D (2, 2, TextureFormat.BGRA32,false);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		//}
		return tex;
	}

	public static byte[] ReadImageFile(string imageLocation)
	{
		byte[] imageData = null;
		FileInfo fileInfo = new FileInfo(imageLocation);
		long imageFileLength = fileInfo.Length;
		FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
		BinaryReader br = new BinaryReader(fs);
		imageData = br.ReadBytes((int)imageFileLength);
		return imageData;
	}
}
