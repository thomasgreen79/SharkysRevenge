using UnityEngine;
using System.Collections;

public class QuizFunctionality : MonoBehaviour {

	public int selGridInt = 0;
	public int answer = 2;
	public bool selSubmit;
	public bool showText = false;
	public bool answeredCorrectly = false;
	public int quizNum = -1;
	public int lessonNum = -1;
	public QuizManagerScript quizManager;

	// Use this for initialization
	void Start () {
		selGridInt = -1;
	}

	public string[] selStrings1 = new string[] {
		" Answer One", 
		" Answer Two", 
		" Answer Three", 
		" Answer Four"};

	public string[] selStrings2 = new string[] {
		" Scooby", 
		" Dooby", 
		" Doo", 
		" Where Are You"};

	public string[] selStrings3 = new string[] {
		" Answer One", 
		" Answer Two", 
		" Answer Three", 
		" Answer Four"};
	

	void OnGUI() {

		if (selGridInt != -1) {
			showText = false;
		}
		GUILayout.BeginArea(new Rect((Screen.width/2)-100, (Screen.height/2)-50, 200, 150));
	
		selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings2, 1, "toggle");
		GUILayout.FlexibleSpace();
		//GUILayout.Button ("Back");
		selSubmit = GUILayout.Button ("Submit");
		if (showText) {
				GUILayout.Label ("Please select an answer first");
		}
		if (selSubmit) {
			if (selGridInt != -1) {
				Debug.Log ("You chose " + selStrings2 [selGridInt]);
				Debug.Log("Stored user answer is: " + quizManager.getUserAnswer(lessonNum, quizNum));
				quizManager.setQuizCompleted(lessonNum, quizNum);
				quizManager.setUserAnswer(lessonNum, quizNum, selGridInt);
				if (selGridInt == quizManager.getCorrectAnswer(lessonNum, quizNum)) {
					answeredCorrectly = true;
				}
				Debug.Log("Stored user answer is: " + quizManager.getUserAnswer(lessonNum, quizNum));
				Debug.Log ("Correct answer is: " + quizManager.getCorrectAnswer(lessonNum, quizNum));
				Application.LoadLevel ("Lesson" + lessonNum + "Quiz" + quizNum + "Completed");
			} else {
				showText = true;
				Debug.Log ("You must first select an answer to submit");
			}
			Debug.Log("quiz number = " + quizNum);
		}
		GUILayout.EndArea();
	}
}
