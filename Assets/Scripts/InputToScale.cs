using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToScale : InputListener {

	public Transform target;
	public float speed;
	public Vector3 endScale;

	private bool scaling = false;
	private Vector3 originalScale;

	void Start() {
		originalScale = target.localScale;
	}

	protected override void Update () {
		base.Update ();
		if (scaling) {
			ZoomIn ();
		} else {
			ZoomOut ();
		}
	}

	protected override bool IsTouching () {
		return Input.GetAxis ("Fire1") != 0;
	}

	protected override void ButtonPressed () {
//		print ("ButtonClicked");
		scaling = true;
	}

	protected override void ButtonReleased () {
//		print ("ButtonReleased");
		scaling = false;
	}

	protected override void ButtonDown () {
//		print ("ButtonDown");
	}

	private void ZoomIn() {
		target.localScale = Vector3.Lerp (target.localScale, endScale, speed * Time.deltaTime);
	}

	private void ZoomOut() {
		target.localScale = Vector3.Lerp (target.localScale, originalScale, speed * Time.deltaTime);
	}
}
