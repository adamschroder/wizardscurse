using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collider) {

		if (collider.gameObject.tag == "Enemy") {
			// move & damage
			Debug.Log("HIT ENEMY");
			collider.gameObject.transform.rigidbody2D.velocity = new Vector2(5f, 0);
			GetComponent<Player>().damagePlayer();
		}

		if (collider.gameObject.tag == "Ground") {
			GetComponent<PlayerController>().grounded = true;
		}

		if (collider.gameObject.tag == "SkeletonMinion") {
		}
	}
}
