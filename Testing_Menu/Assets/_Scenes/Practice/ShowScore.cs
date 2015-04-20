using UnityEngine;
using System.Collections;

public class ShowScore : MonoBehaviour {

	void OnGUI() {
		GUIStyle style = new GUIStyle ();
		style.fontSize = 20;
		style.normal.textColor = Color.white;
		GUI.Label (
			new Rect(20, 20, Screen.width, Screen.height),
			"Score: " + Score.getScore().ToString(),
			style
		);
	}
}
