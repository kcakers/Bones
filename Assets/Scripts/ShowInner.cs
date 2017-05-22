using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInner : MonoBehaviour {

	public float fadeTime = 3.5f;

	private MeshRenderer renderer;
	private bool isShowing = false;
	private string propertyName = "_OutlineColor";

	void Start () {
		renderer = GetComponent<MeshRenderer> ();

		Color color = renderer.material.GetColor (propertyName);
		color.a = 1;
		renderer.material.SetColor (propertyName, color);
	}

	public void Update() {
		FadeControl();
	}

	public void Show() {
		isShowing = true;
		renderer.enabled = true;
	}

	public void Hide() {
		isShowing = false;
		renderer.enabled = false;
	}

	private void FadeControl() {
		Color color = renderer.material.GetColor (propertyName);
		float curAlpha = color.a;
		float targetAlpha = 1;

		if (isShowing) {
			targetAlpha = 0;
		}
			
		color.a = Mathf.Lerp (curAlpha, targetAlpha, fadeTime * Time.deltaTime);
		renderer.material.SetColor (propertyName, color);
	}
}
