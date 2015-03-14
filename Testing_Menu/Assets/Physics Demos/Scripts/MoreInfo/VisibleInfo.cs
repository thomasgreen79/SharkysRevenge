using UnityEngine;
using System.Collections;

public class VisibleInfo : MonoBehaviour {

	public GameObject visibleObject;
	private bool visible;

	void Start() {
		Visible ();
	}


	void Visible () {

		visible = MoreHideInfo.isInfoShown ();

		if (visible) {
			visibleObject.SetActive(true);
		} else {
			visibleObject.SetActive(false);
		}	
	}
}
