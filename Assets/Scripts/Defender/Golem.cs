using UnityEngine;
using System.Collections;

public class Golem : Defender {
	
	public GameObject gun;
	public Animator anim;
	public LayerMask mask;

	public override void Start(){
		base.Start ();
		anim = GetComponent<Animator>();
	}
	

	public override void Update () {
		base.Update ();


		Debug.DrawRay (gun.transform.position, Vector2.right * 3f);
		RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, Vector2.right, 3f, mask.value);

			if (hit.collider != null) {
			anim.SetBool ("Attacking", true);

		} else {
			anim.SetBool ("Attacking", false);
		}
	}
}
