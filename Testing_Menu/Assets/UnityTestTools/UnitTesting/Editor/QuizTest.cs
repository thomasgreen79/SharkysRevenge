using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quizzes{
	[TestFixture]
	public class QuizTests{
		[Test]
		public void getCorrectAnswer(){
			List<int> answers = new List<int> ();
			answers.Add (2);
			answers.Add (0);
			answers.Add (1);
			QuizData qd = new QuizData (3, answers);
			
			int result = qd.getCorrectAnswer (0);
			Assert.AreEqual (2, result);
		}
	}
}
