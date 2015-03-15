using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	public float width;
	public float height;

	void Update () {

		float initialY = transform.position.y;
		Vector3 currentVel = rigidbody.velocity;

		//X Position
		if (transform.position.x > width) {
			transform.position = new Vector3(width, initialY, transform.position.z);
			rigidbody.velocity = new Vector3(-currentVel.x, 0.0f, currentVel.z);
		} else if (transform.position.x < -width) {
			transform.position = new Vector3(-width, initialY, transform.position.z);
			rigidbody.velocity = new Vector3(-currentVel.x, 0.0f, currentVel.z);
		}

		//Y Position
		if (transform.position.z > height) {
			transform.position = new Vector3(transform.position.x, initialY, height);
			rigidbody.velocity = new Vector3(currentVel.x, 0.0f, -currentVel.z);
		} else if (transform.position.z < -height) {
			transform.position = new Vector3(transform.position.x, initialY, -height);
			rigidbody.velocity = new Vector3(currentVel.x, 0.0f, -currentVel.z);
		}
	}
}
