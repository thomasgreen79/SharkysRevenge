using UnityEngine;
using System.Collections;

public class QuizManagerScript : MonoBehaviour {
	
	private class QuizStats : MonoBehaviour{
		static ArrayList quizStatuses;
		static ArrayList quizCorrectAnswers;
		static ArrayList quizUserAnswers;
		
		public QuizStats(int numQuizzes, ArrayList correctAnswersList){
			quizStatuses = new ArrayList();
			quizCorrectAnswers = new ArrayList ();
			quizUserAnswers = new ArrayList ();
			
			for (int i=0; i < numQuizzes; i++) {
				quizStatuses.Add (true);
				quizCorrectAnswers.Add (correctAnswersList[i]);
				quizUserAnswers.Add (-1);
			}
		}
		
		public void setQuizCompleted(int quizNum){
			quizStatuses [quizNum - 1] = false;
		}
		
		public bool getQuizStatus(int quizNum){
			return (bool)quizStatuses [quizNum - 1];
		}
	}
	
	private ArrayList qStats = new ArrayList();
	
	public void init(int numLessons, ArrayList numQuizzes, ArrayList correctAnswersList){
		for (int i=0; i < numLessons; i++) {
			qStats.Add (new QuizStats ((int)numQuizzes [i], (ArrayList)correctAnswersList [i]));
		}
	}
	
	public void setQuizCompleted(int lessonNum, int quizNum){
		((QuizStats)qStats[lessonNum - 1]).setQuizCompleted(quizNum);
	}
	
	public void loadQuiz(int lessonNum, int quizNum){
		if (((QuizStats)qStats [lessonNum - 1]).getQuizStatus(quizNum)) {
			Application.LoadLevel(16);
		} else {
			Application.LoadLevel(18);
		}
	}
}

