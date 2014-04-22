using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class CollisionTrigger : TriggerAction {

	void Start() {
		isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!IsLocked()) {
			PullTrigger(other.gameObject);
		}
	}
	
	public override void ExecuteAction(TriggerAction trigger, GameObject invoker) {
		if (isTrigger) {
			return;
		}

		base.ExecuteAction(trigger, invoker);
		Unlock();
	}
}
