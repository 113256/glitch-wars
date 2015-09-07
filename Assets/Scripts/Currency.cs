using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

	public float startCurrency;
	public Text amt;

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		amt.text = startCurrency.ToString ();
	}
	
	public void Deduct(float amount){
		startCurrency -= amount;
	}

	public void Earn(float amount){
		startCurrency += amount;
	}
}
