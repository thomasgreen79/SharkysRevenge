using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManagerScript : ScriptableObject {

	private static List<string> accessibleScenes;
	private bool canAdd;
	private bool newTouch;
	private bool updatingFeedback;
	public GameObject userFeedback;


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

	public void setCanAddTrue(){
		canAdd = true;
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
			updatingFeedback = true;
			userFeedback.SetActive(true);
		}
	}

	public void setUserFeedback(GameObject userFBack){
		userFeedback = userFBack;
	}

	public void activateUserFeedback(){
		updatingFeedback = true;
		userFeedback.SetActive (true);
	}

	void Update(){
		newTouch = false;
		updatingFeedback = false;
		if (userFeedback != null) {
			if (Input.GetMouseButton (0)) {
				userFeedback.SetActive (false);
			}
			if (Input.touchCount > 0){
				if (Input.GetTouch(0).phase == TouchPhase.Began){
					newTouch = true;
				}
				if (newTouch && !updatingFeedback){
					userFeedback.SetActive (false);
				}
			}
		}
	}
}
