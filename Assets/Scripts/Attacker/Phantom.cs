using UnityEngine;
using System.Collections;

public class Phantom : Attacker {
	
	private GameObject spawnerParent;

	public ParticleSystem healParticle;
	

	public override void Update(){
		//base.Update ();
	}

	private void Repair(){
		spawnerParent = GameObject.Find("Spawners");
		Heal ();
	}

	public override void OnTriggerEnter2D(Collider2D collider){
		print ("abc");
	}

	void Heal(){
		//method1
		//cant do Defender child as Defender cant be used in foreach loop
		/*foreach (Transform child in defenderParent.transform) {
			//we need to access Defender methods so we have to get the defender component of each child 
			Defender defender = child.gameObject.GetComponent<Defender>();

			if(defender) {
				print (defender.getHealth() + 20f);
				defender.setHealth(defender.getHealth() + 20f);
				GameObject particle = Instantiate(healParticle, defender.transform.position, Quaternion.identity) as GameObject;
				//particle.transform.parent = child.transform;

			};
		}*/
		foreach (Transform lane in spawnerParent.transform) {
			//method 2
			Attacker[] attackers = lane.GetComponentsInChildren<Attacker> ();
			foreach (Attacker attacker in attackers) {
				attacker.setHealth (attacker.getHealth () + 20f);
				GameObject particle = Instantiate (healParticle, attacker.transform.position, Quaternion.identity) as GameObject;
			}
		}
	}
	
}
