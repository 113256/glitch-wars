using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public float health;
	public float cost;

	void OnTriggerEnter2D(Collider2D collider){
		Projectiles projectile = collider.gameObject.GetComponent<Projectiles> ();
		if (projectile) {
			print ("missile hit");
			health -= projectile.getDamage();
			projectile.Hit ();
		}
	}

	public float getCost(){
		return cost;
	}

	public virtual void Update () {
		if (health <= 0)
			Destroy (gameObject);
	}

	//only for melee damage
	public void takeDamage(float damage){
		health -= damage;
	}

	public float getHealth(){
		return health;
	}

	public void setHealth(float amount){
		health = amount;
	}


}
