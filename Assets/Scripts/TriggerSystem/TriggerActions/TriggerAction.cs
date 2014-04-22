using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerAction : MonoBehaviour {

	public string triggerName;

	// The locking mechanism for triggers. Semaphores, 0 = unlocked, non-0 = locked
	public int lockingCounter = 0;

	// The triggers that PullTrigger() will call ExecuteAction() on.
	// - this only includes EXTERNAL triggers (ie. triggers not attached to this object)
	// - triggers attached to this object are automatically triggered on PullTrigger()
	public TriggerAction[] triggers;

	//
	public bool isTrigger = false;

	public virtual void ExecuteAction(TriggerAction trigger, GameObject invoker) {
		if (!IsLocked()) {
			Debug.Log("Executed: " + gameObject.name + " from " + trigger.name + " by " + (invoker != null ? invoker.name : "NONE"));
		} else {
		}
	}

	public void PullTrigger(GameObject g) {
		TriggerAction[] ts = GetComponents<TriggerAction>();
		foreach (TriggerAction t in ts) {
			t.ExecuteAction(this, g);
		}
		foreach (TriggerAction t in triggers) {
			t.ExecuteAction(this, g);
		}
	}

	public void Lock() { 
		lockingCounter++;
	}

	public void Unlock() {
		lockingCounter--;
	}

	public bool IsLocked() {
		return lockingCounter != 0;
	}
}
