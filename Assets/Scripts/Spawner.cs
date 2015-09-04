using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public int spawnRate;
	public GameObject[] attackerArray;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 0.000001f, 2);
	}

	void Spawn(){
		GameObject attacker = Instantiate (attackerArray [1], this.transform.position, Quaternion.identity) as GameObject;
		attacker.transform.parent = this.transform;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
