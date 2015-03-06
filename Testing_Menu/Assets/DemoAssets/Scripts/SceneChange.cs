using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

	public void changeScene(int level){
		StartCoroutine (changeSceneHelper (level));
	}

	IEnumerator changeSceneHelper(int level){
		float fadeTime = GameObject.Find ("GameController").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (level);
	}
}
