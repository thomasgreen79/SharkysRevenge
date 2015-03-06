using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {
	private float speed;
	public LayerMask touchInputMask;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 directionVec;
	private Vector3 currVec;
	private bool isClicked;
	GameObject recipient;
	private int fake;
	
	void Update () {
		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit, touchInputMask)){
				if (hit.transform.gameObject.tag == "cueBall"){
					recipient = hit.transform.gameObject;
					if (Input.GetMouseButtonDown(0)){
						isClicked = true;
						startPosition = Input.mousePosition;
					}
				}
			}
			if (isClicked){
//				currVec = new Vector3(4, 0, 3);
//				Debug.DrawRay(startPosition, currVec, Color.red, 2);
//				GL.Begin();
				if (Input.GetMouseButtonUp(0)){
					endPosition = Input.mousePosition;
					directionVec = endPosition - startPosition;
					recipient.SendMessage("updateMovement", directionVec.normalized, SendMessageOptions.DontRequireReceiver);
					recipient.SendMessage ("updateSpeed", (directionVec.magnitude*18), SendMessageOptions.DontRequireReceiver);
					isClicked = false;
				}
			}
		}


		bool supportsTouch = Input.multiTouchEnabled;
		if (supportsTouch) {
			int numTouches = Input.touchCount;
			
			if (numTouches > 0) {
				for (int i = 0; i < numTouches; i++) {
					Touch touch = Input.GetTouch (i);

					Ray ray = camera.ScreenPointToRay(touch.position);
					RaycastHit hit;
					TouchPhase phase;

					if (Physics.Raycast(ray, out hit, touchInputMask)){
						if (hit.transform.gameObject.tag == "cueBall"){
							//Vector2 directionVec = touch.deltaPosition;

							phase = touch.phase;
							if(phase == TouchPhase.Moved){
								isClicked = true;
								startPosition = touch.position;
							}
						}
					}
					if (isClicked){
						phase = touch.phase;
						if (phase == TouchPhase.Ended){
							endPosition = touch.position;
							directionVec = endPosition - startPosition;
							Debug.Log("Vector output: " + directionVec);
							recipient.SendMessage("updateMovement", directionVec.normalized, SendMessageOptions.DontRequireReceiver);
							recipient.SendMessage ("updateSpeed", (directionVec.magnitude/4), SendMessageOptions.DontRequireReceiver);
							isClicked = false;
						}
					}
				}
			}
		}
	}
}
