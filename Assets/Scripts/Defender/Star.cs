using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	private Currency currency;
	private GameObject top;
	private Trophy trophy;

	void Start(){
		top = this.transform.parent.gameObject;
		trophy = top.transform.parent.gameObject.GetComponent<Trophy>();


		currency = GameObject.FindObjectOfType<Currency> ();
	}

	void OnMouseDown(){

		trophy.anim.SetBool ("noStar", true);
		currency.Earn (50f);

		/*
		trophy.anim.SetBool("starClickable", false);
		currency.Earn (50f);


		trophy.noStarTimer = 3;


		Destroy (gameObject);
		*/
	}
}
