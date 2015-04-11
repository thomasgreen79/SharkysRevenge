using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManagerScript : ScriptableObject {

	private static List<string> accessibleScenes;
	private bool canAdd;
	public Text userFeedback;

	public void init(){
		canAdd = false;
		accessibleScenes = new List<string>();
		accessibleScenes.Add ("TitleScreen");
		accessibleScenes.Add ("PreKnowledgeScreen");
		accessibleScenes.Add ("NavigationInstructions");
		accessibleScenes.Add ("LessonMenu");
		accessibleScenes.Add ("LearnObjectivesScreen");
		accessibleScenes.Add ("IntroductionScreen");
		accessibleScenes.Add ("Lesson1_1");
	}

	public void addNewAccessibleScenes(string newAccessibleScenes){
		if (newAccessibleScenes != null){
			if (!accessibleScenes.Contains(newAccessibleScenes) && canAdd){
				string[] newScenes = newAccessibleScenes.Split (' ');
				foreach (string scene in newScenes){
					accessibleScenes.Add (scene);
				}
				canAdd = false;
			}
		}
	}
	
	public void changeSceneButton(string sceneName)
	{
		if (accessibleScenes == null) {
			init ();
		}
		if (accessibleScenes.Contains (sceneName)) {
			canAdd = true;
			Application.LoadLevel (sceneName);
			if (!Application.isLoadingLevel) {
				Debug.LogError ("Failed to load scene: " + sceneName);
			}
		} else {
			if(!userFeedback.gameObject.activeSelf){
				userFeedback.gameObject.SetActive(true);
			}
		}
	}

	void Update(){
		int numTouches = Input.touchCount;
		if (userFeedback != null) {
			if (Input.GetMouseButton (0) || numTouches > 0) {
				userFeedback.gameObject.SetActive (false);
			}
		}
	}
}
