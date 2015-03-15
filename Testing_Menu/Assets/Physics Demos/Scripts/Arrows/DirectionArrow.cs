using UnityEngine;
using System.Collections;

public static class DirectionArrow {

	private static bool showArrow = false;

	public static void ShowArrow () {

		if (showArrow == true) {
			showArrow = false;
			Debug.Log ("showArrow = false");
		} else {
			showArrow = true;
			Debug.Log ("showArrow = true");
		}
	}

	public static bool isArrowShown() {
		return showArrow;
	}
}
