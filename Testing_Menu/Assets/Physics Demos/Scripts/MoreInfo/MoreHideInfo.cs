using UnityEngine;
using System.Collections;

public static class MoreHideInfo {

	private static bool showInfo = false;

	public static void MoreInfo () {

		if (showInfo == true) {
			showInfo = false;
		} else {
			showInfo = true;
		}
	}

	public static bool isInfoShown() {
		return showInfo;
	}

	public static void setShowInfo(bool newShowInfo) {
		showInfo = newShowInfo;
	}
}
