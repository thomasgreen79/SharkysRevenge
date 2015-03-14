using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwapMoreHideInfo : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		bool showInfo = MoreHideInfo.isInfoShown ();
		
		//GameObject button = (GameObject)Instantiate(ButtonPause);
		Text buttonText = gameObject.GetComponent<Text>();
		
		if (showInfo == true) {
			buttonText.text = "Hide Info";
		} else {
			buttonText.text = "More Info";
		}
	}
}
