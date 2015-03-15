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

	private float RAD = 180f / Mathf.PI;		//Convert Radians to Degrees
	private float RAD270 = 1.5f * Mathf.PI;			//270 degrees in radians
	private float RAD90 = Mathf.PI / 2.0f;			//90 degrees in radians

	private LineRenderer line;

	// Use this for initialization
	void Start () {

		line = gameObject.AddComponent<LineRenderer>();

		line.SetVertexCount (2);
		line.SetColors (Color.green, Color.green);
		line.SetWidth (1.5f, 0f);

		line.material = new Material(Shader.Find("Particles/Additive"));

		drawDirectionLine ();

		initialPos = transform.position;
		pausedPos = transform.position;

		float x = Mathf.Cos (angle / RAD) * speed;
		float z = Mathf.Sin (angle / RAD) * speed;

		initialVel = new Vector3 (x, 0, z);
		pausedVel = initialVel;

		rigidbody.velocity = initialVel;
	}
	
	// Update is called once per frame.
	void Update() {

	}

	// LateUpdate is called once per frame after Update() has been executed.
	void LateUpdate() {

	}

	// FixedUpdate is called on a consistent, timed basis.
	void FixedUpdate () {
		
		drawDirectionLine ();
		
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

	float getAngle() {

		float x = rigidbody.velocity.x;
		float z = rigidbody.velocity.z;

		if (z == 0) {
			//Not moving
			if (x == 0) {
				return -1;
			}

			if (x > 0) {
				return 0;
			} else {
				return 180;
			}
		}

		float ang = Mathf.Atan (x / z);
		float newAngle = ang;

		if (z > 0) {
			newAngle = RAD90 - ang;
		} else {
			newAngle = RAD270 - ang;
		}

		return newAngle;
	}

	float getSpeed() {
		return Mathf.Sqrt (Mathf.Pow(rigidbody.velocity.x, 2) + Mathf.Pow (rigidbody.velocity.z, 2));
	}

	void drawDirectionLine() {

		if (DirectionArrow.isArrowShown() == false) {
			line.enabled = false;
			return;
		}
		line.enabled = true;

		float curAngle, lineX, lineZ, scaleX, scaleZ;

		scaleX = transform.localScale.x / 2;
		scaleZ = transform.localScale.z / 2;

		curAngle = getAngle();
		lineX = transform.position.x + Mathf.Cos (curAngle) * scaleX;
		lineZ = transform.position.z + Mathf.Sin (curAngle) * scaleZ;

		line.SetPosition (0, new Vector3(lineX, transform.position.y, lineZ));		

		lineX = transform.position.x + Mathf.Cos (curAngle) * (scaleX + getSpeed());
		lineZ = transform.position.z + Mathf.Sin (curAngle) * (scaleZ + getSpeed());

		line.SetPosition (1, new Vector3(lineX, transform.position.y, lineZ));
	}

	void Restart () {
		pausedPos = initialPos;
		pausedVel = initialVel;
		transform.position = initialPos;
		rigidbody.velocity = initialVel;
	}
}
