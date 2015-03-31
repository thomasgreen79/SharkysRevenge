using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizManagerScript : MonoBehaviour {
	
//	private static QuizData Lesson1;
//	private static QuizData Lesson2;
//	private static QuizData Lesson3;
	private static List<QuizData> Lessons;

	public void initLessons(){
		if (Lessons == null) {
			Lessons = new List<QuizData> ();
			List<int> answers = new List<int> ();
			answers.Add (2);
			answers.Add (0);
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

	public int getUserAnswer(int lessonNum, int quizNum){
		return Lessons[lessonNum-1].getUserAnswer(quizNum-1);
	}

	public int getCorrectAnswer(int lessonNum, int quizNum){
		return Lessons[lessonNum-1].getCorrectAnswer(quizNum-1);
	}

	public void setUserAnswer(int lessonNum, int quizNum, int answer){
		Lessons[lessonNum-1].setUserAnswer(quizNum-1, answer);
	}

	public void setQuizCompleted(int lessonNum, int quizNum){
		Lessons[lessonNum-1].setQuizCompleted (quizNum-1);
	}

	public void loadQuiz(int lessonNum, int quizNum){
		if (!Lessons[lessonNum-1].getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson" + lessonNum + "Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson" + lessonNum + "Quiz" + quizNum + "Completed");
		}
	}

	public void loadQuizByString(string nums){
		int lessonNum = 1;
		int quizNum = 1;
		if (!Lessons[lessonNum-1].getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson" + lessonNum + "Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson" + lessonNum + "Quiz" + quizNum + "Completed");
		}
	}
	

/*
	public void initLesson1(){
		if (Lesson1 == null) {
			List<int> answers = new List<int> ();
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			Lesson1 = new QuizData (answers.Count, answers);
		}
	}
	
	public void initLesson2(){
		if (Lesson2 == null) {
			List<int> answers = new List<int> ();
			answers.Add (3);
			answers.Add (2);
			answers.Add (1);
			Lesson2 = new QuizData (answers.Count, answers);
		}
	}
	
	public void initLesson3(){
		if (Lesson3 == null) {
			List<int> answers = new List<int> ();
			answers.Add (3);
			answers.Add (2);
			answers.Add (1);
			Lesson3 = new QuizData (answers.Count, answers);
		}
	}

	public int getUserAnswerInOne(int quizNum){
		return Lesson1.getUserAnswer(quizNum-1);
	}

	public int getUserAnswerInTwo(int quizNum){
		return Lesson2.getUserAnswer(quizNum-1);
	}
	
	public int getUserAnswerInThree(int quizNum){
		return Lesson3.getUserAnswer(quizNum-1);
	}

	public int getCorrectAnswerInOne(int quizNum){
		return Lesson1.getCorrectAnswer(quizNum-1);
	}

	public int getCorrectAnswerInTwo(int quizNum){
		return Lesson2.getCorrectAnswer(quizNum-1);
	}

	public int getCorrectAnswerInThree(int quizNum){
		return Lesson3.getCorrectAnswer(quizNum-1);
	}
	
	public void setUserAnswerInOne(int quizNum, int answer){
		Lesson1.setUserAnswer(quizNum-1, answer);
	}

	public void setUserAnswerInTwo(int quizNum, int answer){
		Lesson2.setUserAnswer(quizNum-1, answer);
	}

	public void setUserAnswerInThree(int quizNum, int answer){
		Lesson3.setUserAnswer(quizNum-1, answer);
	}

	public void setQuizCompletedInOne(int quizNum){
		Lesson1.setQuizCompleted (quizNum-1);
	}
	
	public void setQuizCompletedInTwo(int quizNum){
		Lesson2.setQuizCompleted (quizNum-1);
	}
	
	public void setQuizCompletedInThree(int quizNum){
		Lesson3.setQuizCompleted (quizNum-1);
	}
	
	public void loadQuizInOne(int quizNum){
		if (!Lesson1.getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson1Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson1Quiz" + quizNum + "Completed");
		}
	}
	
	public void loadQuizInTwo(int quizNum){
		if (!Lesson2.getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson2Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson2Quiz" + quizNum + "Completed");
		}
	}
	
	public void loadQuizInThree(int quizNum){
		if (!Lesson3.getQuizCompleted(quizNum-1)) {
			Application.LoadLevel("Lesson3Quiz" + quizNum);
		} else {
			Application.LoadLevel("Lesson3Quiz" + quizNum + "Completed");
		}
	}
	*/
}

