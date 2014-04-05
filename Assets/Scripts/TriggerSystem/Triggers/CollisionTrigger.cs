using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class CollisionTrigger : Trigger {

	void OnTriggerEnter2D(Collider2D other) {
		PullTrigger(other.gameObject);
	}
	
	public override void SetEnabled(bool b) {
		base.SetEnabled(b);
		collider2D.enabled = b;
	}

}
