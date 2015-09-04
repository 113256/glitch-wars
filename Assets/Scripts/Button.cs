using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	//pass a prefab to each button so that they spawn it
	public GameObject defenderPrefab;

	private Button[] buttonArray;
	//static because we want to access it from other classes without declaring an object first
	public static GameObject selectedDefender;//shared by all buttons

	void Start(){
		buttonArray = GameObject.FindObjectsOfType<Button> ();
	}

	void OnMouseDown(){
		print ("button clicked");

		//set all buttons to black then the one we've clicked to white
		foreach (Button button in buttonArray) {
			button.GetComponent<SpriteRenderer>().color = Color.black;
		}
		//set the one we've clicked to white
		GetComponent<SpriteRenderer> ().color = Color.white;

		selectedDefender = defenderPrefab;
	}
}
