using UnityEngine;
using System.Collections;

public class LevelManagerSplash : MonoBehaviour {

	//seconds to wait before loading next level
	public float autoLoadNextLevelAfter;

	void Start(){
		Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}

}
