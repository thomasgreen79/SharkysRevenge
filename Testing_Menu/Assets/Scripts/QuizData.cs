using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizData {

	private List<bool> quizCompleted;
	private List<int> correctAnswers;
	private List<int> userAnswers;

	public QuizData(int numQuizzes, List<int> answers){
		quizCompleted = new List<bool> ();
		userAnswers = new List<int> ();
		for (int i = 0; i < numQuizzes; i++)
		{
			quizCompleted.Add(false);
			userAnswers.Add(-1);
		}
		correctAnswers = answers;
	}

	public bool getQuizCompleted(int index){
		return quizCompleted[index];
	}

	public int getCorrectAnswer(int index){
		return correctAnswers[index];
	}

	public int getUserAnswer(int index){
		return userAnswers [index];
	}

	public void setQuizCompleted(int index){
		quizCompleted [index] = true;
	}

	public void setUserAnswer(int index, int answer){
		userAnswers [index] = answer;
	}
}
