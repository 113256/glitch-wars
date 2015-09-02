using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range(-1f, 1.5f)] public float currentSpeed;
	public Animator anim; 
	public float health;
	public float shield;

	// Use this for initialization
	public virtual void Start () {
		anim = GetComponent<Animator> ();
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	

	}


	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (health < 0)
			Destroy (gameObject);
	}

	public virtual void OnTriggerEnter2D(Collider2D collider){
		print ("superclass trigger");
		//Debug.Log (name + " trigger enter");
		Defender defender = collider.gameObject.GetComponent<Defender> ();
		if (defender) {
			print (this.name + collider.name + " fight");
			anim.SetTrigger ("Attacking"); 
		}

		/*if (projectile) {
			health -= projectile.getDamage();
		}*/

	}

	//if mob uses projectiles dont use this
	public void StrikeCurrentTarget(float damage)
	{
		print ("damage");
	}

	void OnTriggerExit2D(Collider2D collider) {

		Defender defender = collider.gameObject.GetComponent<Defender> ();
		//Projectiles projectile = gameObject.GetComponent<Projectiles> ();
		if (defender) {
			if (collider.tag == "")
				return; // do nothing
			print (this.name + collider.name + " exit");
			anim.ResetTrigger ("Attacking");  
		}


	}

	public void setSpeed(float speed)
	{
		currentSpeed = speed;
	}

}
