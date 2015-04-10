using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManagerScript : ScriptableObject {

	private static List<string> accessibleScenes;

	public void init(){
		accessibleScenes = new List<string>();
		accessibleScenes.Add ("TitleScreen");
		accessibleScenes.Add ("PreKnowledgeScreen");
		accessibleScenes.Add ("NavigationInstructions");
		accessibleScenes.Add ("LessonMenu");
		accessibleScenes.Add ("LearnObjectivesScreen");
		accessibleScenes.Add ("IntroductionScreen");
		accessibleScenes.Add ("Lesson1_1");
		accessibleScenes.Add ("Lesson2_1");
		accessibleScenes.Add ("Lesson3_1");
		accessibleScenes.Add ("Lesson4_1");
	}

	public void addNewAccessibleScenes(string newAccessibleScenes){
		if (newAccessibleScenes != null){
			if (!accessibleScenes.Contains(newAccessibleScenes)){
				string[] newScenes = newAccessibleScenes.Split (' ');
				foreach (string scene in newScenes){
					accessibleScenes.Add (scene);
				}
			}
		}
	}
	
	public void changeSceneButton(string sceneName)
	{
		if (accessibleScenes == null) {
			init ();
		}
		if (accessibleScenes.Contains (sceneName)) {
			Application.LoadLevel (sceneName);
			if (!Application.isLoadingLevel) {
				Debug.LogError ("Failed to load scene: " + sceneName);
			}
		} else {

		}
	}
	
}
