using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwapPauseStart : MonoBehaviour {
	

	
	// Update is called once per frame
	void Update () {
		bool paused = StartPause.isPaused ();

		//GameObject button = (GameObject)Instantiate(ButtonPause);
		Text buttonText = gameObject.GetComponent<Text>();

		if (paused == true) {
			buttonText.text = "Start";
		} else {
			buttonText.text = "Pause";
		}
	}
}
