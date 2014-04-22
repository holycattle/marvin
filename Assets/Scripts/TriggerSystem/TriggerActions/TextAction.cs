using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextAction : TriggerAction {

	public GUISkin textSkin;
	public bool isAttachedToSound = false;
	public float duration = 4f;
	public string text;
	public Rect textArea;

	//
	private float timeStarted = -1f;

	void Start() {
		textArea = new Rect(textArea.x * Screen.width, textArea.y * Screen.height, textArea.width * Screen.width, textArea.height * Screen.height);
		if (isAttachedToSound) {
			AudioClip c = GetComponent<SoundAction>().oneShotClip;
			duration = c.length;
		}
	}

	void OnGUI() {
		if (timeStarted >= 0) {
			GUISkin gsk = GUI.skin;
			GUI.skin = textSkin;
			GUI.Label(textArea, text);
			GUI.skin = gsk;

			if (timeStarted + duration <= Time.time) {
				timeStarted = -1;
			}
		}
	}

	public override void ExecuteAction(TriggerAction trigger, GameObject invoker) {
		timeStarted = Time.time;
	}

}
