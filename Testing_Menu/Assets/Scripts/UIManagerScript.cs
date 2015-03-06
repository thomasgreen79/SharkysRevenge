using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public void changeSceneButton(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
}
