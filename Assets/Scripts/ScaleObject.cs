using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour {

	public Transform target;
	public float speed;
	public Vector3 targetScale;

	private bool scaling = false;

	void Begin() {
		scaling = true;
	}

	public void End() {
		scaling = false;
	}

	void Update () {
		if (scaling) {
			target.localScale = Vector3.Lerp (target.localScale, targetScale, speed * Time.deltaTime);
		}
	}
}
