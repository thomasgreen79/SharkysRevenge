using UnityEngine;
using System.Collections;

public class ProjectSphere : MonoBehaviour {

	public float speed;
	public float angle;

	private Vector3 initialPos;
	private Vector3 initialVel;
	private Vector3 pausedPos;
	private Vector3 pausedVel;

	private bool wasPaused = true;

	private float RAD = 180f / 3.14159265f;

	// Use this for initialization
	void Start () {

		initialPos = transform.position;
		pausedPos = transform.position;

		float x = Mathf.Cos (angle / RAD) * speed;
		float z = Mathf.Sin (angle / RAD) * speed;

		initialVel = new Vector3 (x, 0, z);
		pausedVel = initialVel;

		rigidbody.velocity = initialVel;

		Debug.Log (x + " " + z);
		Debug.Log (initialVel);
	}
	
	// Update is called once per frame.
	void Update() {

	}

	// LateUpdate is called once per frame after Update() has been executed.
	void LateUpdate() {

	}

	// FixedUpdate is called on a consistent, timed basis.
	void FixedUpdate () {

		bool paused = StartPause.isPaused ();

		if (paused == true) {
			wasPaused = true;
			transform.position = pausedPos;
			rigidbody.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		} else {
			pausedPos = transform.position;

			if (wasPaused == true) {
				//If paused == false and wasPaused == true then it was JUST unpaused.
				wasPaused = false;
				rigidbody.velocity = pausedVel;
			} else {
				//If paused == false and wasPaused == false then it has been previously unpaused and is running.
				pausedVel = rigidbody.velocity;
			}
		}
	}

	void Restart () {
		pausedPos = initialPos;
		pausedVel = initialVel;
		transform.position = initialPos;
		rigidbody.velocity = initialVel;
	}
}
