using System;
using NUnit.Framework;
using UnityEngine;

namespace Navigation {
	
	[TestFixture]
	public class UIManagerTest{
		[Test]
		public void ChangeSceneCorrect (){
			UIManagerScript testObject1 = ScriptableObject.CreateInstance("UIManagerScript")as UIManagerScript;
			String testLevelName = "TitleScreen";
			testObject1.changeSceneButton(testLevelName);
			String actualLevelName = Application.loadedLevelName;
			
			Assert.AreEqual(testLevelName, actualLevelName);
		}
		
		[Test]
		public void ChangeSceneNotCorrect (){
			UIManagerScript testObject2 = ScriptableObject.CreateInstance("UIManagerScript")as UIManagerScript;
			String testLevelName = "LessonMenu";
			String notCorrectName = "not correct";
			testObject2.changeSceneButton(testLevelName);
			String actualLevelName = Application.loadedLevelName;
			
			Assert.AreNotEqual(notCorrectName , actualLevelName);
		}
		
		[Test]
		public void ChangeSceneNotRealLevelName (){
			UIManagerScript testObject3 = ScriptableObject.CreateInstance("UIManagerScript")as UIManagerScript;
			String testLevelName = "NotARealLevelName";
			testObject3.changeSceneButton(testLevelName);
			String actualLevelName = Application.loadedLevelName;
			
			Assert.AreNotEqual(testLevelName , actualLevelName);
		}
	}
}



