using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class LaunchExternalProgram : MonoBehaviour {

    Process launchedGame;

    // Use this for initialization
    void Start () {
        launchedGame = new Process();
        launchedGame.StartInfo.FileName = "notepad.exe";
        launchedGame.StartInfo.Arguments = "";

        //use to create no window when running cmd script
        launchedGame.StartInfo.UseShellExecute = true;
        launchedGame.StartInfo.CreateNoWindow = true;
        launchedGame.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

        Application.runInBackground = true;

        launchedGame.Start();

        //if you want program to halt until script is finished
        //process.WaitForExit();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("q"))
        {
            launchedGame.Kill();
            UnityEngine.Debug.Log("Killed");
        }
            
	}
}
