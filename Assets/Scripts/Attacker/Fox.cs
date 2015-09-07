using UnityEngine;
using System.Collections;

//inheritance
public class Fox : Attacker {
		
		/*/if i dont do this Start() in the base class will run by itself 
		public override void Start(){
			base.Start ();
		}*/

	public override void Update(){
		base.Update ();

		//if our attacker is targeting something isAttacking = true
		isAttacking = (currentTarget != null);
		if(!isAttacking) anim.ResetTrigger ("Attacking");
	}	
	
	public override void OnTriggerEnter2D(Collider2D collider){
		//equivalent of "super" in java
		base.OnTriggerEnter2D (collider);
	}

}
