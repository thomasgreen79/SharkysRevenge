using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwapDirectionArrowText : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		bool showArrow = DirectionArrow.isArrowShown ();		

		Text buttonText = gameObject.GetComponent<Text>();
		
		if (showArrow) {
			buttonText.text = "Hide";
		} else {
			buttonText.text = "Show";
		}
	}
}
