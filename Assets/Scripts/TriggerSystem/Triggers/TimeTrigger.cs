using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeTrigger : TriggerAction {

	public bool startOnAwake = true;
	public bool restartOnFinish = false;
	public float countdownTime;
	private float timeStarted = -1;

	void Start() {
		if (startOnAwake)
			timeStarted = Time.time;
	}

	void Update() {
		if (!(timeStarted < 0) && Time.time >= timeStarted + countdownTime) {
			Debug.Log("Time Triggered!");
			PullTrigger(gameObject);

			// End the trigger
			if (restartOnFinish) {
				RestartTime();
			} else {
				timeStarted = -1;
			}
		}
	}

	public void RestartTime() {
		timeStarted = Time.time;
	}
}
