using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;
	[HideInInspector]
	public bool grounded;
	[HideInInspector]
	public bool movementStopped;

	private Vector3 originalSize;
	private Vector3 originCenter;
	private float colliderScale;

	private BoxCollider boxCollider;
	private Vector3 size;
	private Vector3 center;
	private float buffer = .005f;

	private int collisionDivisionX = 3;
	private int collisionDivisionY = 10;

	Ray ray;
	RaycastHit hit;

	void Start () {

		boxCollider = GetComponent<BoxCollider>();

		colliderScale = transform.localScale.x;
		originalSize = boxCollider.size;
		originCenter = boxCollider.center;
		SetCollider(originalSize, originCenter);
	}

	public void Move (Vector2 moveAmount) {

		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 position = transform.position;

		grounded = false;

		// top & bottom collisions
		for (int i = 0; i < collisionDivisionX; i++) {

			float dir = Mathf.Sign(deltaY);
			// left center and right point of the collider
			float x = (position.x + center.x - size.x/2) + size.x/(collisionDivisionX-1) * i; 
			// bottom of collider
			float y = position.y + center.y + size.y/2 * dir;

			ray = new Ray(new Vector2(x, y), new Vector2(0, dir));

			if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + buffer, collisionMask)) {

				// distance btween player & ground
				float distance = Vector3.Distance(ray.origin, hit.point);
				// stop players movement if it hits a collider
				deltaY = distance > buffer ? distance * dir - buffer * dir: 0;
				grounded = true;
	
				break;
			}
		}

		movementStopped = false;
		// left & right collisions
		for (int i = 0; i < collisionDivisionY; i++) {
			
			float dir = Mathf.Sign(deltaX);
			// left center and right point of the collider
			float x = position.x + center.x + size.x/2 * dir; 
			// bottom of collider
			float y = position.y + center.y - size.y/2 + size.y/(collisionDivisionY-1) * i;
			
			ray = new Ray(new Vector2(x, y), new Vector2(dir, 0));
			
			if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaX) + buffer, collisionMask)) {
				
				// distance btween player & ground
				float distance = Vector3.Distance(ray.origin, hit.point);
				// stop players movement if it hits a collider
				deltaX = distance > buffer ? distance * dir - buffer * dir: 0;
				movementStopped = true;
				break;
			}
		}

		if (!grounded && !movementStopped) {

			Vector3 playerDir = new Vector3(deltaX, deltaY);
			Vector3 origin = new Vector3 (position.x + center.x + size.x/2 * Mathf.Sign(deltaX), position.y + center.y + size.y/2 * Mathf.Sign(deltaY));
			ray = new Ray(origin, playerDir.normalized);

			if (Physics.Raycast(ray, Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY), collisionMask)) {

				grounded = true;
				deltaY = 0;
			}
		}

		Vector2 finalTransform = new Vector2(deltaX, deltaY);

		transform.Translate(finalTransform);
	}

	public void SetCollider(Vector3 s, Vector3 c) {

		boxCollider.size = s;
		boxCollider.center = c;

		size = s * colliderScale;
	}
}
