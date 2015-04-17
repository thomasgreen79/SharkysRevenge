using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LessonMenuLoad : MonoBehaviour {

	public UIManagerScript uMan;
	public Button lesson2Button;
	public Button lesson3Button;
	public Button lesson4Button;

	void OnLevelWasLoaded(){
		if (uMan.ContainsScene("Lesson2_1")){
			lesson2Button.interactable = true;
		}
		if (uMan.ContainsScene("Lesson3_1")){
			lesson3Button.interactable = true;
		}
		if (uMan.ContainsScene("Lesson4_1")){
			lesson4Button.interactable = true;
		}
	}
}
