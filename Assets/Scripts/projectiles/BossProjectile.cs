using UnityEngine;
using System.Collections;

public class BossProjectile : Projectiles {

	private bool moving = false;

	public override void Update(){
		if(moving) transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	private void move(){
		moving = true;
	}
}
