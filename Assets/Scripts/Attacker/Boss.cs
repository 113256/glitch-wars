using UnityEngine;
using System.Collections;

//inheritance
public class Boss : Attacker {
		public float shield;
		public LayerMask mask;
		public GameObject gun;	

		public override void Update(){
			base.Update ();

			Debug.DrawRay (gun.transform.position, -Vector2.right * 3f);
			RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, -Vector2.right, 3f, mask.value);
			
			if (hit.collider != null) {
				anim.SetBool ("Attacking", true);
				
			} else {
				anim.SetBool ("Attacking", false);
			}
		}
	
	public override void OnTriggerEnter2D(Collider2D collider){
		print ("sub");
		Defender defender = collider.gameObject.GetComponent<Defender> ();
		//must check if colliding with a defender first before tag or get null reference exception
		if (defender) {
			if(defender.tag == "DefenderWall"){
			print ("boss attacking wall");
			}
		}

		Projectiles projectile = collider.gameObject.GetComponent<Projectiles> ();
		
		if (projectile) {
			if(shield > 0){
				print ("shielded");
				shield -= projectile.getDamage();
			} else {
				health -= projectile.getDamage();
			}
		}

		//equivalent of "super" in java
		base.OnTriggerEnter2D (collider);


		
	}

}
