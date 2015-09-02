using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public float health;

	void OnTriggerEnter2D(Collider2D collider){
		Projectiles projectile = collider.gameObject.GetComponent<Projectiles> ();
		if (projectile) {
			health -= projectile.getDamage();
		}
	}

	void Update () {
		if (health < 0)
			Destroy (gameObject);
	}


}
