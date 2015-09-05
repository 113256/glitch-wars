using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	private GameObject projectileParent;
	public GameObject gun;

	void Start(){
		projectileParent = GameObject.Find("Projectiles");

		//good unity practice- create if it doesnt exist
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");}
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		//the "gun" child object is just there so that the projectile can spawn on top of it (but not as a child)
		//projectiles will spawn under a separate gameObject (so that active projectiles wont be destroyed if the attacker is destroyed)
		newProjectile.transform.position = gun.transform.position;
	}

}
