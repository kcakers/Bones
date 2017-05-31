using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour {

	public Transform target;
	public float speed;
	public Vector3 targetScale;

	private bool scaling = false;
	private Vector3 startScale;
	private Vector3 scale;

	void Start() {
		startScale = target.localScale;
		scale = targetScale;
	}

	public void Begin() {
		scaling = true;
	}

	public void End() {
		scaling = false;
	}

	public void Reverse() {
		scale = startScale;
	}

	void Update () {
		if (scaling) {
			target.localScale = Vector3.Lerp (target.localScale, scale, speed * Time.deltaTime);
		}
	}
}
