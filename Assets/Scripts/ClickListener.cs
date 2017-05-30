using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour {

	private bool touching = false;

	void Update () {
		TouchControl ();
	}

	private void TouchControl() {
		if (IsTouching()) { // pressing
			// if the were not pressing before...
			if (!touching) {
				touching = true;
				ButtonClicked();
			} else { // already touching
				ButtonDown();
			}
		} else {
			if (touching) { // if they were touching...
				touching = false;
				ButtonReleased();
			}
		}
	}

	protected bool IsTouching() {
		return Input.GetAxis ("Fire1") != 0;
	}

	protected void ButtonClicked() {
		print("button pressed");
	}

	protected void ButtonReleased() {
		print("button released");
	}

	protected void ButtonDown() {
		print("button down");
	}
}
