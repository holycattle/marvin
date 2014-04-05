using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerAction : MonoBehaviour {

	public virtual void ExecuteAction(Trigger trigger, GameObject invoker) {
		Debug.Log("Executed: " + gameObject.name + " from " + trigger.name + " by " + (invoker != null ? invoker.name : "NONE"));
	}

}
