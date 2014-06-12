using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ladder : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Debug.Log("Player Enter");
			other.GetComponent<PlayerController>().CanClimb = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			Debug.Log("Player Exit");
			other.GetComponent<PlayerController>().CanClimb = false;
		}
	}

}
