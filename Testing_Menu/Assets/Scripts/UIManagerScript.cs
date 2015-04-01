using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public void changeSceneButton(string sceneName)
	{

		Application.LoadLevel(sceneName);
		if (!Application.isLoadingLevel)
		{
			Debug.LogError("Failed to load scene: " + sceneName);
		}
	}
	
}
