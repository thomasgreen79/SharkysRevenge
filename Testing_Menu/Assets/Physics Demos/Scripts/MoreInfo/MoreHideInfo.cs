using UnityEngine;
using System.Collections;

public static class MoreHideInfo {

	private static bool showInfo = false;

	public static void MoreInfo () {

		if (showInfo == true) {
			showInfo = false;

			Debug.Log ("showInfo = false");
		} else {
			showInfo = true;
			Debug.Log ("showInfo = true");
		}
	}

	public static bool isInfoShown() {
		return showInfo;
	}
}
