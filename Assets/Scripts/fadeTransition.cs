using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeTransition : MonoBehaviour {

	//fade time in seconds
	public float fadeInTime;

	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();//image component of the same gameobject

	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad < fadeInTime){
			//fade in
			float alphaChange = Time.deltaTime / fadeInTime;
			//a = alpha
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else {
			//make panel inactive so it wont appear anymore
			gameObject.SetActive(false);
		}
	}
}
