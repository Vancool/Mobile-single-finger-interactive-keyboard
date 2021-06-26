using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdjustAlpha : MonoBehaviour {
   public GameObject[] btns;
    public Slider alphaSlider;
    private Controler c;
    public static bool changingAlpha = false; 

	// Use this for initialization
	void Start () {
         btns = GameObject.FindGameObjectsWithTag("button");
        alphaSlider.maxValue = 1;
        alphaSlider.minValue = 0.2f;
        alphaSlider.onValueChanged.AddListener(onChange);
        c = GetComponent<Controler>();
	}

    private void onChange(float theValue)
    {
        changingAlpha = true;
        ButtonTest.alpha = theValue;
        //c.changeLayout();
        for (int i = 0; i < btns.Length; i++)
        {
            (btns[i].GetComponent<Button>()).GetComponent<Image>().color=new Color(1,1,1,theValue);
        }
    }

    // Update is called once per frame
    void Update () {
        if (changingAlpha = true && Input.touchCount == 0)
        {
            changingAlpha = false;
        }
	}
  
}
