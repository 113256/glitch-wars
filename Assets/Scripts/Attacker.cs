using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range(-1f, 1.5f)] public float currentSpeed;
	public Animator anim; 
	public float health;
	public float damage;
	private Defender currentTarget;
	private bool isAttacking;

	// Use this for initialization
	public void Start () {
		print ("start");
		anim = GetComponent<Animator> ();
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	

	}


	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (health < 0)
			Destroy (gameObject);

		//if our attacker is targeting something isAttacking = true
		isAttacking = (currentTarget != null);
		if(!isAttacking) anim.ResetTrigger ("Attacking");
	}

	public virtual void OnTriggerEnter2D(Collider2D collider){
		print ("superclass trigger");
		//Debug.Log (name + " trigger enter");
		Defender defender = collider.gameObject.GetComponent<Defender> ();
		//if defender exists
		if (defender) {
			print (this.name + collider.name + " fight");

			currentTarget = collider.gameObject.GetComponent<Defender> ();

			anim.SetTrigger ("Attacking"); 
		}

		/*if (projectile) {
			health -= projectile.getDamage();
		}*/

	}



	//if mob uses projectiles dont use this
	//only for melee attacks
	public void StrikeCurrentTarget()
	{
		currentTarget.takeDamage (damage);
	}

	//dont use this since its not called when the object is destoryed since the collider doesnt exist
	/*
	void OnTriggerExit2D(Collider2D collider) {

		Defender defender = collider.gameObject.GetComponent<Defender> ();
		//Projectiles projectile = gameObject.GetComponent<Projectiles> ();
		if (defender) {
			if (collider.tag == "")
				return; // do nothing
			print (this.name + collider.name + " exit");
			anim.ResetTrigger ("Attacking");  
		}


	}*/

	public void setSpeed(float speed)
	{
		currentSpeed = speed;
	}

}
