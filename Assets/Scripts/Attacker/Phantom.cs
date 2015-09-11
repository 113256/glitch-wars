using UnityEngine;
using System.Collections;

public class Phantom : Attacker {
	
	private GameObject spawnerParent;

	public ParticleSystem healParticle;
	

	public override void Update(){
		base.Update ();
	}

	private void Repair(){
		spawnerParent = GameObject.Find("Spawners");
		Heal ();
	}

	public override void OnTriggerEnter2D(Collider2D collider){
		
		Projectiles projectile = collider.gameObject.GetComponent<Projectiles> ();
		if (projectile) {
			health -= projectile.getDamage();
			projectile.Hit ();
		}
	}

	void Heal(){
		//child of each lane (which are children of Spawners)
		foreach (Transform lane in spawnerParent.transform) {
			Attacker[] attackers = lane.GetComponentsInChildren<Attacker> ();
			foreach (Attacker attacker in attackers) {
				attacker.addHealth (20f);
				GameObject particle = Instantiate (healParticle, attacker.transform.position, Quaternion.identity) as GameObject;
				if(particle==null){
					print("null");
				}
				//particle.transform.SetParent(attacker.transform, false);
			}
		}
	}
	
}
