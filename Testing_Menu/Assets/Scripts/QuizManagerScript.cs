using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quizzes{
public class QuizManagerScript : ScriptableObject {
	
	private static List<QuizData> Lessons;
	public UIManagerScript uiManager;
	public int lessonNum;
	public int quizNum;
	public GameObject notSubmittedText;
	public GameObject unavailableScene;

	public void initLessons(){
		if (Lessons == null) {
			Lessons = new List<QuizData> ();
			
			List<int> answers = new List<int> ();
			answers.Add (0);
			answers.Add (0);
			answers.Add (2);
			Lessons.Add (new QuizData (answers.Count, answers));

			List<int> answers1 = new List<int> ();
			answers1.Add (3);
			Lessons.Add (new QuizData (answers1.Count, answers1));

			List<int> answers2 = new List<int> ();
			answers2.Add (0);
			answers2.Add (1);
			answers2.Add (3);
			Lessons.Add (new QuizData (answers2.Count, answers2));

			List<int> answers3 = new List<int> ();
			answers3.Add (2);
			answers3.Add (3);
			answers3.Add (3);
			Lessons.Add (new QuizData (answers3.Count, answers3));
		}
	}

	public void setLessonNum(int lNum){
		lessonNum = lNum;
	}

	public void setQuizNum(int qNum){
		quizNum = qNum;
	}

	public List<QuizData> getLessons(){
		return Lessons;
	}

	public int getUserAnswer(){
		if (Lessons == null) {
			initLessons ();
		}
		return Lessons[lessonNum-1].getUserAnswer(quizNum-1);
	}

	public int getCorrectAnswer(){
		if (Lessons == null) {
			initLessons ();
		}
		return Lessons[lessonNum-1].getCorrectAnswer(quizNum-1);
	}

	public string getQuizText(int answerNum){
		if (Lessons == null) {
			initLessons ();
		}
		return Lessons [lessonNum - 1].getQuizTextByAnswerNum (quizNum - 1, answerNum - 1);
	}

	public void setUserAnswer(int answer){
		if (Lessons == null) {
			initLessons ();
		}
		if (Lessons == null) {
			initLessons ();
		}
		Lessons[lessonNum-1].setUserAnswer(quizNum-1, answer);
	}

	public void setQuizCompleted(){
		if (Lessons == null) {
			initLessons ();
		}
		Lessons[lessonNum-1].setQuizCompleted (quizNum-1);
	}

	public void addQuizText(string text){
		if (Lessons == null) {
			initLessons ();
		}
		Lessons [lessonNum - 1].addQuizText (quizNum - 1, text);
	}

	public void loadQuiz(){
		if (Lessons == null) {
			initLessons ();
		}
		if (!Lessons[lessonNum-1].getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson" + lessonNum + "_Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson" + lessonNum + "_Quiz" + quizNum + "_Completed");
		}
	}

	public void loadQuizByString(string nums){
		if (Lessons == null) {
			initLessons ();
		}
		string[] numStrings = nums.Split (' ');
		int lessonNum = int.Parse (numStrings[0]);
		int quizNum = int.Parse (numStrings[1]);
		if (uiManager.ContainsScene ("Lesson" + lessonNum + "_Quiz" + quizNum)) {
			if (!Lessons [lessonNum - 1].getQuizCompleted (quizNum - 1)) {
				uiManager.changeSceneButton ("Lesson" + lessonNum + "_Quiz" + quizNum);
				//Application.LoadLevel("Lesson" + lessonNum + "_Quiz" + quizNum);
			} else {
				uiManager.changeSceneButton ("Lesson" + lessonNum + "_Quiz" + quizNum + "_Completed");
				//Application.LoadLevel("Lesson" + lessonNum + "_Quiz" + quizNum + "_Completed");
			}
		} else {
			uiManager.setUserFeedback(unavailableScene);
			uiManager.activateUserFeedback();
		}
	}

	public void submitQuiz(string scenesToAdd){
		if (getUserAnswer () > -1) {
			uiManager.setCanAddTrue();
			uiManager.addNewAccessibleScenes(scenesToAdd);
			setQuizCompleted ();
			loadQuiz ();
		} else {
			uiManager.setUserFeedback(notSubmittedText);
			uiManager.activateUserFeedback();
		}
	}
}
}

