using UnityEngine;
using System.Collections;

public class QuizFunctionality : MonoBehaviour {

	public int selGridInt = 0;
	public int answer = 2;
	public bool selSubmit;
	public bool showText = false;

	// Use this for initialization
	void Start () {
		selGridInt = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	public string[] selStrings = new string[] {" Answer One", " Answer Two", " Answer Three", " Answer Four"};

	void OnGUI() {

		if (selGridInt != -1) {
			showText = false;
		}
		GUILayout.BeginArea(new Rect((Screen.width/2)-100, (Screen.height/2)-50, 200, 150));
	
		selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 1, "toggle");
		GUILayout.FlexibleSpace();
		selSubmit = GUILayout.Button ("Submit");
		if (showText) {
				GUILayout.Label ("Please select an answer first");
		}
		if (selSubmit) {
						if (selGridInt != -1) {
								Debug.Log ("You chose " + selStrings [selGridInt]);
								if (selGridInt == answer) {
										Application.LoadLevel ("Lesson1Page5");
								}
						} else {
								showText = true;
								Debug.Log ("You must first select an answer to submit");
						}
				}
		GUILayout.EndArea();
	}
}
