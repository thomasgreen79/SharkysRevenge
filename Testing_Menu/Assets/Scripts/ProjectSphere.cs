using UnityEngine;
using System.Collections;

public class ProjectSphere : MonoBehaviour {

	public float speed;
	public Vector3 direction;
	public float arenaSize;
	private Vector3 initialPos;

	private bool paused = false;
	private Vector3 pausedPos;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (direction * speed * Time.deltaTime);
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (paused == true) {
			transform.position = pausedPos;
			return;
		}

		Vector3 currentVel = rigidbody.velocity;

		if (transform.position.x > arenaSize) {
			transform.position = new Vector3(arenaSize, initialPos.y, transform.position.z);
			rigidbody.velocity = new Vector3(-currentVel.x, 0.0f, currentVel.z);
		} else if (transform.position.x < -arenaSize) {
			transform.position = new Vector3(-arenaSize, initialPos.y, transform.position.z);
			rigidbody.velocity = new Vector3(-currentVel.x, 0.0f, currentVel.z);
		}

		if (transform.position.z > arenaSize) {
			transform.position = new Vector3(transform.position.x, initialPos.y, arenaSize);
			rigidbody.velocity = new Vector3(currentVel.x, 0.0f, -currentVel.z);
		} else if (transform.position.z < -arenaSize) {
			transform.position = new Vector3(transform.position.x, initialPos.y, -arenaSize);
			rigidbody.velocity = new Vector3(currentVel.x, 0.0f, -currentVel.z);
		}

		if (transform.position.y != initialPos.y) {
			transform.position = new Vector3(transform.position.x, initialPos.y, transform.position.z);
			rigidbody.velocity = new Vector3(currentVel.x, 0.0f, currentVel.z);
		}
	}

	void Restart () {
		transform.position = initialPos;
		pausedPos = initialPos;
		rigidbody.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		rigidbody.AddForce (direction * speed * Time.deltaTime);
	}

	void Pause () {
		if (paused == false) {
			paused = true;
			pausedPos = transform.position;
		} else {
			paused = false;
		}
	}
}
