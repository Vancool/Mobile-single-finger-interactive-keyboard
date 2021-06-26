using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttoncolor : MonoBehaviour {
	private bool highlight = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void changecolor() {
		highlight = !highlight;
		if (highlight) {
			this.GetComponent<Image> ().color = new Color (0.4f, 0.78f, 1, 0.5f);
		
		} else
			this.GetComponent<Image> ().color = new Color (1, 1, 1, 0.5f);

    }
}
