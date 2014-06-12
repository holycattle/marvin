/*
1. flip animation based on left or right key
2. set velocity

*/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform groundDetector;
	private const int MAX_SPEED = 3;
	private const float CLIMB_SPEED = 3;
	private bool facingRight;
	Animator animator;

	// Movement
	private bool _canClimb = false;
	private bool _isClimbing = false;

	void Start() {
		animator = this.GetComponent<Animator>();
		facingRight = true;
	}

	void Update() {
		// Handle Climbing
		if (!_canClimb) {
			_isClimbing = false;
		} else if (Mathf.Abs(Input.GetAxis("Vertical")) > 0 && _canClimb) {
			_isClimbing = true;
		}
		animator.SetBool("IsClimbing", _isClimbing);
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			Jump();
		}
	}

	void FixedUpdate() {
		float horizMovement = Input.GetAxis("Horizontal");
		animator.SetFloat("Speed", Mathf.Abs(horizMovement));

		float newYVelocity = rigidbody2D.velocity.y;
		float vertMovement = Input.GetAxis("Vertical");
		if (_isClimbing) {
			if (vertMovement == 0)
				vertMovement = -0.5f;
			newYVelocity = CLIMB_SPEED * vertMovement;
		}

		if (horizMovement > 0 && !facingRight) {
			Flip();
		} else if (horizMovement < 0 && facingRight) {
			Flip();
		}

		// One way platforms.
		if (newYVelocity > 0 || vertMovement < 0) {
			Debug.Log("Ignore Collision");
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("OneWayPlatform"), true);

			Collider2D ground = GetGround();
			if (ground.gameObject.layer == LayerMask.NameToLayer("OneWayPlatform")) {
				ground.collider2D.isTrigger = true;
			}

//			Debug.Log("Get Ground: " + GetGround().name);
//			if (GetGround().name == "OneWayPlatform") {
//				Destroy(GetGround().gameObject);
//			}

			rigidbody2D.WakeUp();
			Debug.Log("Awake?: " + rigidbody2D.IsAwake());
//			if (newYVelocity == 0)
//				newYVelocity = -5f;
		} else {
			Debug.Log("Not Ignore Collision");
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("OneWayPlatform"), false);
		}

		rigidbody2D.velocity = new Vector2(horizMovement * MAX_SPEED, newYVelocity);
	}

	void Flip() {
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
		facingRight = !facingRight;
	}

	void Jump() {
		if (IsGrounded() || _isClimbing) {
			rigidbody2D.velocity = new Vector2(0, 12.5f);
			_isClimbing = false;
		}
	}

	public Collider2D GetGround() {
		RaycastHit2D rh = Physics2D.Raycast(transform.position, new Vector2(0, -1), //
		                                    Vector2.Distance(transform.position, groundDetector.position), //
		                                    1 << LayerMask.NameToLayer("Environment") | 1 << LayerMask.NameToLayer("OneWayPlatform"));
		return rh.collider;
	}

	public bool IsGrounded() {
		return GetGround() != null;
	}

	public bool CanClimb {
		set { this._canClimb = value; }
		get { return this._canClimb; }
	}
}
