using UnityEngine;
using System.Collections;

public class GamerCamera : MonoBehaviour {

	private Transform target;
	private float trackSpeed = 10;

	public void SetTarget (Transform t) {

		target = t;
	}

	void LateUpdate () {

		if (target) {

			float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
			float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
			transform.position = new Vector3(x, y, transform.position.z);
		}
	}

	private float IncrementTowards(float spd, float target, float increaseSpeed) {
		
		// spd == speed, get better at naming things
		if (spd == target) {
			
			return spd;
		} 
		else {
			
			float dir = Mathf.Sign (target - spd);
			spd += increaseSpeed * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - spd))? spd: target;
		}
	}
}
