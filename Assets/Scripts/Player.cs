using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {

		health = 100;
	}
	
	public void damagePlayer () {

		health = health - 10;
		// handle death
		// debounce so that one hit doesn't kill the player
	}
}
