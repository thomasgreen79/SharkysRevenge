using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quizzes{
public class QuizData {

	private List<bool> quizCompleted;
	private List<int> correctAnswers;
	private List<int> userAnswers;
	private List<List<string>> quizTexts;

	public QuizData(int numQuizzes, List<int> answers){
		quizCompleted = new List<bool> ();
		userAnswers = new List<int> ();
		quizTexts = new List<List<string>>();
		for (int i = 0; i < numQuizzes; i++)
		{
			quizCompleted.Add(false);
			userAnswers.Add(-1);
			quizTexts.Add (new List<string>());
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

	public string getQuizTextByAnswerNum(int index, int answerNum){
		return quizTexts [index] [answerNum];
	}

	public void setQuizCompleted(int index){
		quizCompleted [index] = true;
	}

	public void setUserAnswer(int index, int answer){
		userAnswers [index] = answer;
	}

	public void addQuizText(int index, string text){
		quizTexts [index].Add (text);
	}
}
}
