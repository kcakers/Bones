using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDetector : MonoBehaviour {

	private ClickToZoom zoomer;
	private Collider lastCollider;

	// Use this for initialization
	void Start () {
		zoomer = GetComponent<ClickToZoom> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!zoomer) return;
		
		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (ray, out hit, 20000f)) {
			if (hit.collider.tag == "HitBox") {
				print ("Hit a box!");
				hit.collider.gameObject.GetComponentInChildren<ShowInner> ().Show ();
				lastCollider = hit.collider;
			} else {
				print ("Not aiming at a box");
				if (lastCollider) {
					lastCollider.GetComponentInChildren<ShowInner> ().Hide ();
					lastCollider = null;
				}
			}
		}
	}
}
