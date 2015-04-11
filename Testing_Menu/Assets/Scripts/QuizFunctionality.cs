using UnityEngine;
using System.Collections;

namespace Quizzes{
public class QuizFunctionality : MonoBehaviour {

	public int selGridInt = 0;
	public int answer = 2;
	public bool selSubmit;
	public bool selContinue;
	public bool showText = false;
	public bool answeredCorrectly = false;
	public int quizNum = -1;
	public int lessonNum = -1;
	public QuizManagerScript quizManager;
	public Texture aTexture;
	public Texture2D whiteTex;

	// Use this for initialization
	void Start () {
		selGridInt = -1;
	}

	void OnGUI() {

		if (selGridInt != -1){
			showText = false;
		}
		if (Application.loadedLevelName.Contains ("Completed")) {
			bool toggleTxt = false;
			GUILayout.BeginArea (new Rect ((Screen.width / 2) - 300, (Screen.height / 2) - 50, 200, 150));

			for (int i = 0; i < quizManager.getNumPossibleAnswers(lessonNum, quizNum); i++){
				if (quizManager.getCorrectAnswer(lessonNum, quizNum) == i){
					GUI.contentColor = Color.green;
				} else if (quizManager.getUserAnswer(lessonNum, quizNum) == i){
					GUI.contentColor = Color.red;
				} else {
					GUI.contentColor = Color.white;
				}
				toggleTxt = GUI.Toggle(new Rect(0, 10+i*25, 200, 30), toggleTxt, quizManager.getQuizTexts(lessonNum, quizNum)[i]);
			}
			GUILayout.FlexibleSpace ();
			GUILayout.EndArea ();
		} else {
			GUILayout.BeginArea (new Rect ((Screen.width / 2) - 300, (Screen.height / 2) - 50, 200, 100));	
				selGridInt = GUILayout.SelectionGrid (selGridInt, quizManager.getQuizTexts(lessonNum, quizNum), 1, "toggle");
			GUILayout.FlexibleSpace ();
			GUILayout.EndArea();

			GUILayout.BeginArea (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) + 50, 200, 50));
				GUIStyle gStyle = new GUIStyle("button");
				/*
				 * gStyle.normal.background = whiteTex;
				gStyle.fixedHeight = 30;
				gStyle.fixedWidth = 160;
				gStyle.alignment = TextAnchor.MiddleCenter;
				GUI.backgroundColor = Color.white;
				GUI.color = Color.white;
				GUI.contentColor = Color.black;
				*/
			selSubmit = GUILayout.Button ("Submit", gStyle);

			if (showText) {
				GUILayout.Label ("Please select an answer first");
			}
			GUILayout.EndArea();

			if (selSubmit) {
				if (selGridInt != -1) {
					//Debug.Log ("You chose " + selStrings2 [selGridInt]);
					//Debug.Log ("Stored user answer is: " + quizManager.getUserAnswer (lessonNum, quizNum));
					quizManager.setQuizCompleted (lessonNum, quizNum);
					quizManager.setUserAnswer (lessonNum, quizNum, selGridInt);
					if (selGridInt == quizManager.getCorrectAnswer (lessonNum, quizNum)) {
						answeredCorrectly = true;
					}
					//Debug.Log ("Stored user answer is: " + quizManager.getUserAnswer (lessonNum, quizNum));
					//Debug.Log ("Correct answer is: " + quizManager.getCorrectAnswer (lessonNum, quizNum));
					Application.LoadLevel ("Lesson" + lessonNum + "Quiz" + quizNum + "Completed");
				} else {
					showText = true;
					Debug.Log ("You must first select an answer to submit");
				}
				//Debug.Log ("quiz number = " + quizNum);
			}
			//GUILayout.EndArea ();
		}
	}
}
}
