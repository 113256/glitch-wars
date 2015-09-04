using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject projectileParent;
	public GameObject gun;

	void Start(){
		projectileParent = GameObject.Find("Projectiles");
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		//the "gun" child object is just there so that the projectile can spawn on top of it
		newProjectile.transform.position = gun.transform.position;
	}

}
