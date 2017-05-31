using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputListener : MonoBehaviour {

	private bool touching = false;

	virtual protected void Update () {
		TouchControl ();
	}

	private void TouchControl() {
        OVRInput.Update();
		if (IsTouching()) { // pressing
			// if the were not pressing before...
			if (!touching) {
				touching = true;
				ButtonPressed();
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

	protected abstract bool IsTouching ();
	protected abstract void ButtonPressed ();
	protected abstract void ButtonReleased ();
	protected abstract void ButtonDown ();
}
