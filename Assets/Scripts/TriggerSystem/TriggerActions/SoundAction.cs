using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SoundAction : TriggerAction {

	public AudioClip oneShotClip;

	public override void ExecuteAction(Trigger trigger, GameObject invoker) {
		base.ExecuteAction(trigger, invoker);

		if (oneShotClip != null) {
			audio.PlayOneShot(oneShotClip);
		} else {
			audio.Play();
		}
	}
}
