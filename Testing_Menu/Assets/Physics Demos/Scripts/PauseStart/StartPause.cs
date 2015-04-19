using UnityEngine;
using System.Collections;

public static class StartPause {

	private static bool paused = true;

	public static void Pause () {
		if (paused == true) {
			paused = false;
		} else {
			paused = true;
		}
	}

	public static bool isPaused() {
		return paused;
	}

	public static void setPaused(bool newPaused) {
		paused = newPaused;
	}
}
