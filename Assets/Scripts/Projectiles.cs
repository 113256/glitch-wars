using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
		
	}


	public void StrikeCurrentTarget(float damage)
	{
		print ("damage");
	}
}
