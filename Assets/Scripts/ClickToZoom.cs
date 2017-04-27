using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr;

public class ClickToZoom : MonoBehaviour {

	private bool touching = false;
	private float originalFOV;
	public float zoomFOV = 20;

	void Start () {
		originalFOV = Camera.main.fieldOfView;
	}

	void Update () {
		if (Input.touchCount > 0 || Input.GetAxis("Fire1") != 0) { // pressing
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

	private void ButtonClicked() {
		touching = true;
	}

	private void ButtonReleased() {
		touching = false;
	}

	private void ZoomIn() {
		Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, zoomFOV, 7f * Time.deltaTime);
		FixFieldOfView (1, 1, Camera.main.fieldOfView);
	}

	private void ZoomOut() {
		Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, originalFOV, 7f * Time.deltaTime);
		FixFieldOfView (1, 1, Camera.main.fieldOfView);
	}

	private void FixFieldOfView(float stereoMultiplier = 1, float zoom = 0, float fov = 0) {
		StereoController stereoCtrl = GvrViewer.Controller;
		stereoCtrl.stereoMultiplier = stereoMultiplier;
		stereoCtrl.matchByZoom = zoom;
		stereoCtrl.matchMonoFOV = fov;
		stereoCtrl.UpdateStereoValues ();
	}
}
