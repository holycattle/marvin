using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OneWayPlatform : MonoBehaviour {

	void OnTriggerExit2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			collider2D.isTrigger = false;
		}
	}

}
