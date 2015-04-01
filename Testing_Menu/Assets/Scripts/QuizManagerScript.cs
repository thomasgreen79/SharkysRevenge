using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quizzes{
public class QuizManagerScript : MonoBehaviour {
	
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
}
}

