using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public void changeSceneButton(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}

	public void printRes(){
		print ("Current width is: " + Screen.width);
		print ("Current height is: " + Screen.height);
	}
}
