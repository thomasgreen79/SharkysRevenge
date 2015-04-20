using UnityEngine;
using System.Collections;

public class Encircle : MonoBehaviour {

	private LineRenderer line;
	public float radius;

	// Use this for initialization
	void Update () {
		float posX, posZ;
		float RAD = 180 / Mathf.PI;
		line = this.GetComponent<LineRenderer> ();
		for (int i = 0; i < 17; i++) {
			posX = transform.position.x + Mathf.Sin((22.5f * i) / RAD) * radius;
			posZ = transform.position.z + Mathf.Cos((22.5f * i) / RAD) * radius;
			Vector3 pos = new Vector3(posX, transform.position.y, posZ);
			line.SetPosition(i, pos);
		} 
	}
}
