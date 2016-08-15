using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance = null;

	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
			print ("duplicate music player removed");
		} else {
		instance = this;
		GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
