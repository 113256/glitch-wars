using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	
	public float DestroyTime;
	
	void Start()
	{
		StartCoroutine("DestroyMe");
	}
	
	IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds(DestroyTime);
		Destroy(gameObject);
	}
}

