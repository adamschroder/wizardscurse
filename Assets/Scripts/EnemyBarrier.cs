using UnityEngine;
using System.Collections;

public class EnemyBarrier : MonoBehaviour {

	private bool timing;
	private GameObject currentGameObject;
	float countdown;

	void Start () {

		timing = false;
	}

	void Update () {

		if (timing) {
			countdown -= Time.deltaTime;
			if(countdown <= 0) {
				Debug.Log("in countdown");
				this.currentGameObject.GetComponent<EnemyBehavior>().changeDir = false;
				timing = false;
				this.currentGameObject = null;
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D collider) {

		if (collider.gameObject.tag == "Enemy") {
			collider.gameObject.GetComponent<EnemyBehavior>().changeDir = true;
			this.currentGameObject = collider.gameObject;
			startTimer(2);
		}
	}

	void startTimer(float time) {
		timing = true;
		countdown = time;
	}
}
