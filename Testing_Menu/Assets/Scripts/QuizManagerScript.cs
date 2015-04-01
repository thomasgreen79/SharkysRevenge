using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quizzes{
public class QuizManagerScript : MonoBehaviour {
	
	private static List<QuizData> Lessons;
	private string[] selStrings1 = new string[] {
		" Answer One", 
		" Answer Two", 
		" Answer Three", 
		" Answer Four"};
		
	private string[] selStrings2 = new string[] {
		" Scooby", 
		" Dooby", 
		" Doo", 
		" Where Are You"};
	
	private string[] selStrings3 = new string[] {
		" Answer One", 
		" Answer Two", 
		" Answer Three", 
		" Answer Four"};

	public void initLessons(){
		if (Lessons == null) {
			Lessons = new List<QuizData> ();
			List<string[]> texts = new List<string[]>();
			texts.Add (selStrings1);
			texts.Add (selStrings2);
			texts.Add (selStrings3);
			
			List<int> answers = new List<int> ();
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			Lessons.Add (new QuizData (answers.Count, answers, texts));

			List<int> answers1 = new List<int> ();
			answers1.Add (1);
			answers1.Add (3);
			answers1.Add (2);
			Lessons.Add (new QuizData (answers1.Count, answers1, texts));

			List<int> answers2 = new List<int> ();
			answers2.Add (3);
			answers2.Add (2);
			answers2.Add (0);
			Lessons.Add (new QuizData (answers2.Count, answers2, texts));
		}
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

	public int getNumPossibleAnswers(int lessonNum, int quizNum){
		if (Lessons == null) {
			initLessons ();
		}
		return Lessons[lessonNum-1].getNumPossibleAnswers (quizNum-1);
	}

	public string[] getQuizTexts(int lessonNum, int quizNum){
		if (Lessons == null) {
			initLessons ();
		}
		return Lessons [lessonNum - 1].getTexts (quizNum);
	}

	public void setUserAnswer(int lessonNum, int quizNum, int answer){
		if (Lessons == null) {
			initLessons ();
		}
		Lessons[lessonNum-1].setUserAnswer(quizNum-1, answer);
	}

	public void setQuizCompleted(int lessonNum, int quizNum){
		if (Lessons == null) {
			initLessons ();
		}
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
		int lessonNum = 1;
		int quizNum = 1;
		if (!Lessons[lessonNum-1].getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson" + lessonNum + "Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson" + lessonNum + "Quiz" + quizNum + "Completed");
		}
	}
}
}

