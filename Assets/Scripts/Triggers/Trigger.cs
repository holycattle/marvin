using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour {

	public TriggerAction[] triggers;

	void Start() {
		Debug.Log("Trigger Started!");
	}

	void OnTriggerEnter(Collider c) {
		Debug.Log("Collisioned!");
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Collisioned@2D!");
	}

	public void PullTrigger() {
	}
}
