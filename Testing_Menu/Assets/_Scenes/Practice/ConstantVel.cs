using UnityEngine;
using System.Collections;

public class ConstantVel : MonoBehaviour {

	public bool constantX;
	public bool constantZ;

	public float XSpeed;
	public float ZSpeed;

	// Update is called once per frame
	void Update () {
		if (constantX) {
			if (rigidbody.velocity.x < 0) {
				rigidbody.velocity = new Vector3(-XSpeed, rigidbody.velocity.y, rigidbody.velocity.z);
			} else  {
				rigidbody.velocity = new Vector3(XSpeed, rigidbody.velocity.y, rigidbody.velocity.z);
			}
		}

		if (constantZ) {
			if (rigidbody.velocity.z < 0) {
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -ZSpeed);
			} else  {
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, ZSpeed);
			}
		}
	}
}
