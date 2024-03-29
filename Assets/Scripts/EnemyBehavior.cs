﻿using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	private Transform player;
	public bool changeDir;

	void Start () {

		this.changeDir = false;
		player = GameObject.Find("Player").transform;
	}
	
	void Update () {

		// follow the player
		if (player.transform.position.x <= transform.position.x && !this.changeDir) {
			this.transform.position = new Vector3 (this.transform.position.x - 1f * Time.deltaTime, this.transform.position.y, this.transform.position.z);
		} 
		else {
			this.transform.position = new Vector3 (this.transform.position.x + 1f * Time.deltaTime, this.transform.position.y, this.transform.position.z);
		}
	}
}
