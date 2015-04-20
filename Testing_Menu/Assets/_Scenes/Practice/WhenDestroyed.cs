using UnityEngine;
using System.Collections;

public class WhenDestroyed : MonoBehaviour {

	Vector3 initPos;
	public int scoreValue;

	// Use this for initialization
	void Start () {
		initPos = transform.position;
	}
	
	void OnDestroy () {
		transform.position = initPos;
		Score.increaseScore (scoreValue);
	}
}
