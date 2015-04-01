using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quizzes{
	[TestFixture]
	public class QuizTests{
		[Test]
		public void getQuizNotCompleted(){
			List<int> answers = new List<int> ();
			List<string[]> texts = new List<string[]> ();
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			QuizData qd = new QuizData (3, answers, texts);

			bool result = qd.getQuizCompleted (0);
			Assert.AreEqual (false, result);
		}
		[Test]
		public void getQuizCompleted(){
			List<int> answers = new List<int> ();
			List<string[]> texts = new List<string[]> ();
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			QuizData qd = new QuizData (3, answers, texts);

			qd.setQuizCompleted (0);
			bool result = qd.getQuizCompleted (0);
			Assert.AreEqual (true, result);
		}
		[Test]
		public void getCorrectAnswer(){
			List<int> answers = new List<int> ();
			List<string[]> texts = new List<string[]> ();
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			QuizData qd = new QuizData (3, answers, texts);
			
			int result = qd.getCorrectAnswer (0);
			Assert.AreEqual (2, result);
		}
		[Test]
		public void getUserNoAnswer(){
			List<int> answers = new List<int> ();
			List<string[]> texts = new List<string[]> ();
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			QuizData qd = new QuizData (3, answers, texts);

			int result = qd.getUserAnswer (0);
			Assert.AreEqual (-1, result);
		}
		[Test]
		public void getUserAnswer(){
			List<int> answers = new List<int> ();
			List<string[]> texts = new List<string[]> ();
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			QuizData qd = new QuizData (3, answers, texts);

			qd.setUserAnswer (0, 3);
			int result = qd.getUserAnswer (0);
			Assert.AreEqual (3, result);
		}
		[Test]
		public void getQuizTexts(){
			List<int> answers = new List<int> ();
			List<string[]> texts = new List<string[]> ();
			string[] testTexts = new string[1];
			testTexts [0] = "testText";
			texts.Add (testTexts);
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			QuizData qd = new QuizData (3, answers, texts);

			string result = qd.getTexts (0) [0];
			Assert.AreEqual ("testText", result);
		}
		[Test]
		public void getNumAnswers(){
			List<int> answers = new List<int> ();
			List<string[]> texts = new List<string[]> ();
			string[] testTexts = new string[1];
			testTexts [0] = "testText";
			texts.Add (testTexts);
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			QuizData qd = new QuizData (3, answers, texts);
			
			int result = qd.getNumPossibleAnswers(0);
			Assert.AreEqual (1, result);
		}
	}
}
