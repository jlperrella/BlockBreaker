using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("level load requested for: "+name);
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}
	
	/* REFERENCE
	public void QuitRequest() {
		Debug.Log ("Quit Requested");
		//application.quit is a bad practice re: it won't work in debug or web builds, it will work on iOS but is considered bad form
		Application.Quit();
	}
	*/
	
	public void LoadNextLevel () {
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}