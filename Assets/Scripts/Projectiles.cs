using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	public float damage;
	public float speed;

	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
		
	}

	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}



	public void Hit(){

		Destroy (gameObject);
	}


	public float getDamage(){
		return damage;
	}


}
