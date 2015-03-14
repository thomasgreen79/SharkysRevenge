using UnityEngine;
using System.Collections;

public static class StartPause {

	private static bool paused = true;

	public static void Pause () {
		if (paused == true) {
			paused = false;
			Debug.Log ("paused = false");
		} else {
			paused = true;
			Debug.Log ("paused = true");
		}
	}

	public static bool isPaused() {
		return paused;
	}
}
