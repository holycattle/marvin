using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : TriggerAction {

	public string triggerName;
	public bool isTriggerable = false;
	public TriggerAction[] triggers;

	public void PullTrigger(GameObject g) {
		TriggerAction[] ts = GetComponents<TriggerAction>();
		foreach (TriggerAction t in ts) {
			t.ExecuteAction(this, g);
		}
		foreach (TriggerAction t in triggers) {
			t.ExecuteAction(this, g);
		}
	}

	public override void ExecuteAction(Trigger trigger, GameObject invoker) {
		if (isTriggerable) {
			SetEnabled(true);
		}
	}

	public virtual void SetEnabled(bool b) {
		enabled = b;
	}
}
