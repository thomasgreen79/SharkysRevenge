using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizManagerScript : MonoBehaviour {
	
	private static QuizData Lesson1;
	private static QuizData Lesson2;
	private static QuizData Lesson3;
	
	public void initLesson1(int numQuizzes){
		List<int> answers = new List<int> ();
		answers.Add (3);
		answers.Add (2);
		answers.Add (1);
		Lesson1 = new QuizData (numQuizzes, answers);
	}
	
	public void initLesson2(int numQuizzes){
		List<int> answers = new List<int> ();
		answers.Add (3);
		answers.Add (2);
		answers.Add (1);
		Lesson2 = new QuizData (numQuizzes, answers);
	}
	
	public void initLesson3(int numQuizzes){
		List<int> answers = new List<int> ();
		answers.Add (3);
		answers.Add (2);
		answers.Add (1);
		Lesson3 = new QuizData (numQuizzes, answers);
	}
	
	public void setQuizCompletedInOne(int quizNum){
		Lesson1.setQuizCompleted (quizNum);
	}
	
	public void setQuizCompletedInTwo(int quizNum){
		Lesson2.setQuizCompleted (quizNum);
	}
	
	public void setQuizCompletedInThree(int quizNum){
		Lesson3.setQuizCompleted (quizNum);
	}
	
	public void loadQuizInOne(int quizNum){
		if (!Lesson1.getQuizCompleted(quizNum)) {
			Application.LoadLevel("Lesson1Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson1QuizCompleted" + quizNum);
		}
	}
	
	public void loadQuizInTwo(int quizNum){
		if (!Lesson2.getQuizCompleted(quizNum)) {
			Application.LoadLevel("Lesson2Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson2QuizCompleted" + quizNum);
		}
	}
	
	public void loadQuizInThree(int quizNum){
		if (!Lesson3.getQuizCompleted(quizNum)) {
			Application.LoadLevel("Lesson3Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson3QuizCompleted" + quizNum);
		}
	}
}

