using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToZoom : MonoBehaviour {

	private bool touching = false;
	private float originalFOV;

	public float zoomFOV = 15;
	public float zoomSpeed = 3.5f;

	[HideInInspector]
	public bool isZooming = false;

	void Start () {
		originalFOV = Camera.main.fieldOfView;
	}

	void Update () {
		TouchControl ();
	}

	private void TouchControl() {
		if (IsTouching()) { // pressing
			// if the were not pressing before...
			if (!touching) {
				ButtonClicked();
			} else { // already touching
				ZoomIn();
			}
		} else {
			if (touching) { // if they were touching...
				ButtonReleased();
			}
			ZoomOut();
		}
	}

	private bool IsTouching() {
		if(Input.GetMouseButtonDown(0) || Input.touchCount > 0 || (Input.GetAxis("Fire1") != 0))
		{
			return true;
		}

		return false;
	}

	private void ButtonClicked() {
		touching = true;
		isZooming = true;
//        print("button clicked");
	}

	private void ButtonReleased() {
		touching = false;
		isZooming = false;
//        print("button unclicked");
    }

	private void ZoomIn() {
		//Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
	}

	private void ZoomOut() {
		//Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, originalFOV, zoomSpeed * Time.deltaTime);
	}
}