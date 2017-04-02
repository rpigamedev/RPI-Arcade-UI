using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class LaunchExternalProgram : MonoBehaviour {

    Process launchedGame;

    string PathToGames;

    // Function to launch the game directly (no shim, no force quitting)
    public void launchGameDirect (string ExeFolder, string ExeName, string Args) {
        launchedGame = new Process();

        // Use to create no window when running from shell
        launchedGame.StartInfo.UseShellExecute = true;
        launchedGame.StartInfo.CreateNoWindow = true;
        launchedGame.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

        // Set game launch parameters
        launchedGame.StartInfo.WorkingDirectory = PathToGames + "/" + ExeFolder;
        launchedGame.StartInfo.FileName = ExeName;
        launchedGame.StartInfo.Arguments = Args;

        Application.runInBackground = true;

        launchedGame.Start();

        //UI will halt until game is finished
        launchedGame.WaitForExit();
    }

    // Function to launch the game using the AutoHotKey shim (less direct, allows force quitting)
    public void launchGameShim (string ExeFolder, string ExeName, string Args) {
        launchedGame = new Process();

        // Use to create no window when running from shell
        launchedGame.StartInfo.UseShellExecute = true;
        launchedGame.StartInfo.CreateNoWindow = true;
        launchedGame.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

        // Set shim launch parameters. Assuming Shim is in game folder root.
        launchedGame.StartInfo.WorkingDirectory = PathToGames;
        launchedGame.StartInfo.FileName = "CabinetUIShim.exe";

        // Collect arguments
        // First working directory, then EXE name, then the game's args.
        // Example: "C:/CabinetUI/Data/Games/Super Toast/" "SuperToast.exe" -hardmode -decaf
        launchedGame.StartInfo.Arguments = "\"" + PathToGames + "/" + ExeFolder + "\" ";
        launchedGame.StartInfo.Arguments += "\"" + ExeName +"\" ";
        launchedGame.StartInfo.Arguments += Args;

        // Start the game
        Application.runInBackground = true;
        launchedGame.Start();

        // UI will halt until shim script is finished
        launchedGame.WaitForExit();
    }

    // Use this for initialization
    void Start () {
        PathToGames = Application.dataPath + "/Games";
    }
	
	// Update is called once per frame
	void Update () {
            
	}
}
