using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	public float damage;

	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
		
	}


	public float getDamage(){
		return damage;
	}
}
