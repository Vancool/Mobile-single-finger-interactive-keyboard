using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {
	
	public Plane mmmm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Plane m_plane = new Plane (Camera.main.transform.forward*-1,this.transform.position);

		if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved&&gesture.activategesture) || Input.GetMouseButton (0))) {
			Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			this.transform.position=(Input.mousePosition);
			float rayDist;
			if (m_plane.Raycast (mRay, out rayDist)) {
				this.transform.position = mRay.GetPoint (rayDist);
			} else {
			   
			}

		}
	}
}
