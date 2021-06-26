using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestinputField : MonoBehaviour {
   public InputField ipf;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setText()
    {
        ipf.ActivateInputField();
        ipf.caretPosition = 0;
        ipf.text = "nihao";
    }
}
