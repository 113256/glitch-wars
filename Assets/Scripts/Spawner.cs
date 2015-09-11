using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public int spawnRate;
	public GameObject[] attackerArray;
	private int randomNum;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 0.000001f, 4);
	}

	void Spawn(){
		//GameObject attacker = Instantiate (attackerArray [1], this.transform.position, Quaternion.identity) as GameObject;
		randomNum = Random.Range (0, 2); 

		GameObject attacker = Instantiate (attackerArray [randomNum]) as GameObject;
		Boss boss = attacker.gameObject.GetComponent<Boss> ();
		Phantom phantom = attacker.gameObject.GetComponent<Phantom> ();
		Fox fox = attacker.gameObject.GetComponent<Fox> ();
		//if the mob is boss/phantom spawn it ahead of other mobs because they appear into the screen; they dont walk into the screen
		if (boss || phantom || fox) {
			Vector3 pos = new Vector3 (this.transform.position.x - 3, this.transform.position.y);
			attacker.transform.position = pos;
		} else {
			attacker.transform.position = this.transform.position;
		}
		attacker.transform.parent = this.transform;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
