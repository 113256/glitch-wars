using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private LevelManager levelManager;
	private static GameObject DefenderParent;
	public Text scoreboard;
	public int score;


	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		DefenderParent = GameObject.Find("Defender");
	}

	public void addScore(int amount){
		print ("added score" + amount);
		score += amount;
	}

	// Update is called once per frame
	void Update () {

		scoreboard.text = score.ToString ();

		if (DefenderParent.transform.childCount <=0) {
			levelManager.LoadLevel("03b Lose");
		}

		if (score >= 3000) {
			levelManager.LoadLevel("03a Win");
		}
	}


}
