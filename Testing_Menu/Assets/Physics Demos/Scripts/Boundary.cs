using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	public bool restrictX;
	public bool restrictZ;
	public float xDist;
	public float zDist;

	public bool blockYIncrease;
	public bool blockYDecrease;


	private Vector3 init;

	void Start() {
		init = transform.position;
	}

	void Update () {
		float currentY = transform.position.y;
		Vector3 currentVel = rigidbody.velocity;

		//X Position
		if (restrictX) {
			if (transform.position.x > xDist) {
				transform.position = new Vector3 (xDist, currentY, transform.position.z);
				rigidbody.velocity = new Vector3 (-currentVel.x, 0.0f, currentVel.z);
			} else if (transform.position.x < -xDist) {
				transform.position = new Vector3 (-xDist, currentY, transform.position.z);
				rigidbody.velocity = new Vector3 (-currentVel.x, 0.0f, currentVel.z);
			}
		}

		//Y Position
		if (restrictZ) {
			if (transform.position.z > zDist) {
				transform.position = new Vector3 (transform.position.x, currentY, zDist);
				rigidbody.velocity = new Vector3 (currentVel.x, 0.0f, -currentVel.z);
			} else if (transform.position.z < -zDist) {
				transform.position = new Vector3 (transform.position.x, currentY, -zDist);
				rigidbody.velocity = new Vector3 (currentVel.x, 0.0f, -currentVel.z);
			}
		}

		if (blockYIncrease) {
			if (currentY > init.y) {
				transform.position = new Vector3(transform.position.x, init.y, transform.position.z);
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z);
			}
		}

		if (blockYDecrease) {
			if (currentY < init.y) {
				transform.position = new Vector3(transform.position.x, init.y, transform.position.z);
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z);
			}
		}
	}
}
