using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hittest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Image img = GetComponent<Image>();

        img.alphaHitTestMinimumThreshold = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
