using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quizzes{
public class QuizManagerScript : ScriptableObject {
	
	private static List<QuizData> Lessons;

	public void initLessons(){
		if (Lessons == null) {
			Lessons = new List<QuizData> ();
			
			List<int> answers = new List<int> ();
			answers.Add (0);
			answers.Add (2);
			answers.Add (1);
			Lessons.Add (new QuizData (answers.Count, answers));

			List<int> answers1 = new List<int> ();
			answers1.Add (1);
			answers1.Add (3);
			answers1.Add (2);
			Lessons.Add (new QuizData (answers1.Count, answers1));

			List<int> answers2 = new List<int> ();
			answers2.Add (3);
			answers2.Add (2);
			answers2.Add (0);
			Lessons.Add (new QuizData (answers2.Count, answers2));
		}
	}

	public List<QuizData> getLessons(){
		return Lessons;
	}

	public int getUserAnswer(int lessonNum, int quizNum){
		if (Lessons == null) {
			initLessons ();
		}
		return Lessons[lessonNum-1].getUserAnswer(quizNum-1);
	}

	public int getCorrectAnswer(int lessonNum, int quizNum){
		if (Lessons == null) {
			initLessons ();
		}
		return Lessons[lessonNum-1].getCorrectAnswer(quizNum-1);
	}

	public void setUserAnswer(string input){
		if (Lessons == null) {
			initLessons ();
		}
		string[] numStrings = input.Split (' ');
		int lessonNum = int.Parse (numStrings[0]);
		int quizNum = int.Parse (numStrings[1]);
		int answer = int.Parse (numStrings[2]);
		if (Lessons == null) {
			initLessons ();
		}
		Lessons[lessonNum-1].setUserAnswer(quizNum-1, answer);
	}

	public void setQuizCompleted(string input){
		if (Lessons == null) {
			initLessons ();
		}
			string[] numStrings = input.Split (' ');
			int lessonNum = int.Parse (numStrings[0]);
			int quizNum = int.Parse (numStrings[1]);
		Lessons[lessonNum-1].setQuizCompleted (quizNum-1);
	}

	public void loadQuiz(int lessonNum, int quizNum){
		if (Lessons == null) {
			initLessons ();
		}
		if (!Lessons[lessonNum-1].getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson" + lessonNum + "Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson" + lessonNum + "Quiz" + quizNum + "Completed");
		}
	}

	public void loadQuizByString(string nums){
		if (Lessons == null) {
			initLessons ();
		}
		string[] numStrings = nums.Split (' ');
		int lessonNum = int.Parse (numStrings[0]);
		int quizNum = int.Parse (numStrings[1]);
		if (!Lessons[lessonNum-1].getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson" + lessonNum + "_Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson" + lessonNum + "_Quiz" + quizNum + "_Completed");
		}
	}
}
}

