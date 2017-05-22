using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInner : MonoBehaviour {

	private MeshRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<MeshRenderer> ();
	}

	public void Show() {
		renderer.enabled = true;
	}

	public void Hide() {
		renderer.enabled = false;
	}
}
