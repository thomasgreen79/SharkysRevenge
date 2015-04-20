using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	public int scoreToWin;

	bool showGUI = false;

	// Update is called once per frame
	void Update () {
		if (Score.getScore () >= scoreToWin) {
			showGUI = true;
		}
	}

	void OnGUI() {
		if (showGUI == true) {
			GUIStyle style = new GUIStyle();
			style.fontSize = 60;
			style.normal.textColor = Color.white;
			GUI.Label (
				new Rect(170, 150, Screen.width, Screen.height),
				"SUCCESS!",
				style
			);
		}
	}
}
