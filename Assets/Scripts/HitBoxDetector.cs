using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDetector : MonoBehaviour {

	private Collider lastCollider;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (ray, out hit, 20000f)) {
			if (hit.collider.tag == "HitBox") {
				hit.collider.gameObject.GetComponentInChildren<ShowInner> ().Show ();
				lastCollider = hit.collider;
			} else {
				if (lastCollider) {
					lastCollider.GetComponentInChildren<ShowInner> ().Hide ();
					lastCollider = null;
				}
			}
		}
	}
}
