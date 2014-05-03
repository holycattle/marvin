/*
1. flip animation based on left or right key
2. set velocity

*/

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private const int MAX_SPEED = 3;
	private bool facingRight;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float d = Input.GetAxis("Horizontal");
		animator.SetFloat("Speed", Mathf.Abs(d));

		if(d > 0 && !facingRight) {
			Flip();
		} else if(d < 0 && facingRight) {
			Flip();
		}
	}

	void Flip() {
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
		facingRight = !facingRight;
	}
}
