using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Quizzes{
public class QuizCompletedScript : MonoBehaviour {

	public int lessonNum;
	public int quizNum;
	public QuizManagerScript quizManager;

	void OnLevelWasLoaded(){
			int i = 0;
			foreach (Transform child in this.transform) {
				Toggle toggleRef = child.GetComponent<Toggle>();
				if (quizManager.getUserAnswer (lessonNum, quizNum) == i){
					toggleRef.isOn = true;
				}
				foreach (Transform secondChild in child.transform){
					if (secondChild.name == "Label"){
						if (quizManager.getCorrectAnswer (lessonNum, quizNum) == i) {
							secondChild.GetComponentInChildren<Text>().color = Color.green;
						} else if (quizManager.getUserAnswer (lessonNum, quizNum) == i) {
							secondChild.GetComponentInChildren<Text>().color = Color.red;
						} else {
							secondChild.GetComponentInChildren<Text>().color = Color.white;
						}
					}
				}
				i++;
			}
	}
}
}