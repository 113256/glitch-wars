using UnityEngine;
using System.Collections;

public class Trophy : Defender {

	/*public bool starCountDown;
	public float starTime;
	public float noStarTimer;*/
	public Animator anim;
	private GameObject Top;
	private GameObject star;
	//public GameObject newstar;


	public override void Start(){
		base.Start ();
		anim = GetComponent<Animator>();
		Top = this.transform.Find("top").gameObject;
		star = Top.transform.Find ("star").gameObject;
	}

	void StarNotClickable(){
		if (star.GetComponent<BoxCollider2D>()) {
			BoxCollider2D collider = star.GetComponent<BoxCollider2D> ();
			Destroy(collider);
		}
	}

	void StarClickable(){
		//add collider so you can click it (star)
		if (!star.GetComponent<BoxCollider2D>()) {
			BoxCollider2D newCollider = star.AddComponent<BoxCollider2D> ();
		}


	}

	
	public override void Update(){
		base.Update ();
	
		if( anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			anim.SetBool ("noStar", false);
		}
		
		//instead of using timers in the script just make a new clip as a timer and instead of 
		//destroying and instantiating a new star just make a 5 second clip where the star isnt active

		/*
		//starTime starts counting down after a star spawns
		if (starCountDown) {
			starTime-=Time.deltaTime;
		}
		//after starTime counts down the star will be clickable
		if (starTime <= 0) {
			starCountDown = false;
			starTime = 5;
			anim.SetTrigger("starClickable");
		}

		//after star is destroyed after being clicked noStarTimer counts down
		if((starTime == 5 && anim.GetBool("starClickable")==false))
		{
			noStarTimer-=Time.deltaTime;
			if(noStarTimer<=0){
				GameObject newStarObject = Instantiate(newstar) as GameObject;

				newStarObject.transform.name = "star"; //or else itwill be "star(clone)"
				newStarObject.transform.parent = Top.transform;

				//local so it will be relative to parents position
				newStarObject.transform.localPosition= new Vector2(0.003000021f,0.187f);
				newStarObject.transform.localRotation = Quaternion.Euler(0,0,0);
				newStarObject.transform.localScale += new Vector3(0.5089988f, 0.4790425f,0);
				//because the old ones were destroyed so set again after creating a new star
				Top = this.transform.Find("top").gameObject;
				star = Top.transform.Find ("star").gameObject;

				starCountDown = true;
			}
			
		}

		*/
	}

}
