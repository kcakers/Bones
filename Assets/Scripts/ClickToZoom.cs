using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToZoom : MonoBehaviour {

	private Camera mainCam;
	private bool touching = false;
	private float originalFOV;
	public float zoomFOV = 20;

	// Use this for initialization
	void Start () {
		mainCam = GetComponent<Camera>();
		originalFOV = mainCam.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 || Input.GetAxis("Fire1") != 0) { // pressing
			//print("touching");
			//Camera.main.fieldOfView = 20;
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
	}

	private void zoomOut() {
		mainCam.fieldOfView = Mathf.Lerp (mainCam.fieldOfView, originalFOV, 7f * Time.deltaTime);
	}
}
