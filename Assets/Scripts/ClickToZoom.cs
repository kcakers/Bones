using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr;

public class ClickToZoom : MonoBehaviour {

	public Camera mainCam;
	private StereoController stereoController;
	private bool touching = false;
	private float originalFOV;
	public float zoomFOV = 20;
	//public GVRViewer viewer;

	// Use this for initialization
	void Start () {
		//stereoController = GetComponent<StereoController>();
		//stereoController.matchByZoom;
		originalFOV = mainCam.fieldOfView;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 || Input.GetAxis("Fire1") != 0) { // pressing
			//print("touching");
			// if the were not pressing before...
			if (!touching) {
				buttonClicked();
			} else { // already touching
				zoomIn();
			}
		} else {
			if (touching) { // if they were touching...
				buttonReleased();
			}
			zoomOut();
		}
	}

	private void buttonClicked() {
		touching = true;
	}

	private void buttonReleased() {
		touching = false;
	}

	private void zoomIn() {
		mainCam.fieldOfView = Mathf.Lerp (mainCam.fieldOfView, zoomFOV, 7f * Time.deltaTime);
		FixFieldOfView (1, 1, mainCam.fieldOfView);
	}

	private void zoomOut() {
		mainCam.fieldOfView = Mathf.Lerp (mainCam.fieldOfView, originalFOV, 7f * Time.deltaTime);
		FixFieldOfView (1, 1, mainCam.fieldOfView);
	}

	private void FixFieldOfView(float stereoMultiplier = 1, float zoom = 0, float fov = 0) {
		StereoController stereoCtrl = GvrViewer.Controller;
		stereoCtrl.stereoMultiplier = stereoMultiplier;
		stereoCtrl.matchByZoom = zoom;
		stereoCtrl.matchMonoFOV = fov;
		stereoCtrl.UpdateStereoValues ();
	}
}
