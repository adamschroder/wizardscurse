using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool grounded;
	private PlayerPhysics playerPhysics;
	private bool facingRight = true;

	// Use this for initialization
	void Start () {
	
		this.grounded = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.RightArrow)) {
			this.transform.position = new Vector3(this.transform.position.x + 5f * Time.deltaTime, this.transform.position.y, this.transform.position.z);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)) {
			this.transform.position = new Vector3 (this.transform.position.x - 5f * Time.deltaTime, this.transform.position.y, this.transform.position.z);
		}

		if (this.grounded) {
			if (Input.GetButtonDown("Jump")) {
				transform.rigidbody2D.velocity = new Vector2(0, 12f);
				this.grounded = false;
			}
		} 
	}

	void FixedUpdate () {

		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move * 1, rigidbody2D.velocity.y);
		
		if (move > 0 && !facingRight) {
			Flip();
		} else if (move < 0 && facingRight) {
			Flip();
		}
	}

	void Flip () {

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
