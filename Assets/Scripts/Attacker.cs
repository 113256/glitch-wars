using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range(-1f, 1.5f)] public float currentSpeed;
	public Animator anim; 
	public float health;
	private float maxHealth;
	public float damage;
	//public so subclasses can use
	public Defender currentTarget;
	public bool isAttacking;

	public int score;
	private ScoreManager scoreManager;

	// Use this for initialization
	public void Start () {
		maxHealth = health;
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
		anim = GetComponent<Animator> ();
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;


	}

	public int getScore(){
		return this.score;
	}

	// Update is called once per frame
	public virtual void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (health < 0) {
			scoreManager.addScore (getScore ());
			Destroy (gameObject);

		}


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

		Projectiles projectile = collider.gameObject.GetComponent<Projectiles> ();
		if (projectile) {
			health -= projectile.getDamage();
			projectile.Hit ();
		}

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

	public float getHealth(){
		return health;
	}

	public void addHealth(float amount){
		if (health + amount > maxHealth) {
			health = maxHealth;
		} else {
			health += amount;
		}
	}

	public void setHealth(float amount){

		health = amount;
	}

}
