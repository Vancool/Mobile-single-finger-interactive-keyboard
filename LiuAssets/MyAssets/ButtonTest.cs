using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour {
   
    public Button[] btns;

    public static float blankRate = 0.85f; 
    float clickCount = 0;
  
    public static float btnWid;

    public static float r=400;

    public static float alpha=0.5f;

    public  static float off_set_x, off_set_y;
    public static float max_angle = 90;
    public static float btnLen;

    public float ns_off_set_x, ns_off_set_y;
    public float ns_btnLen;
    public float ns_max_angle;
   // float pos_x, pos_y;
    float btnsSize;
    Quaternion rotation0;
    // Use this for initialization
    void Start () {
        setText();
        off_set_x = ns_off_set_x;
        off_set_y = ns_off_set_y;
        max_angle = ns_max_angle;
        btnLen = ns_btnLen;

        btnsSize = btns.Length;
        float delt_angle = max_angle / btnsSize;
        rotation0 = btns[0].GetComponent<RectTransform>().rotation;
        for (int i = 0;i<btnsSize;i++)
        {
            float arc_angle = (float)(delt_angle * i / 180 * 3.1415926);
           RectTransform rectTransform =  btns[i].GetComponent<RectTransform>();
            rectTransform.position = (new Vector3(-r*(float)System.Math.Sin(arc_angle)+off_set_x, r*(float)System.Math.Cos(arc_angle)+off_set_y, 0));
            rectTransform.Rotate(new Vector3(0, 0, 1), delt_angle * i);
            Image img = btns[i].GetComponent<Image>();
            img.color = new Color(1, 1, 1, alpha);
          // rectTransform.position = new Vector3(0, 0, 0);
          
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            changeLayout();
        }
    }
    public void changeLayout()
    {
        

        float delt_angle = max_angle / btnsSize;

        btnWid = (float)(r * max_angle / 180 * 3.1415926 / btnsSize*blankRate);

        for (int i = 0; i < btnsSize; i++)
        {
            float arc_angle = (float)(delt_angle * i / 180 * 3.1415926);
            RectTransform rt = btns[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(btnWid, btnLen);
            rt.position = (new Vector3(-r * (float)System.Math.Sin(arc_angle) + off_set_x, r * (float)System.Math.Cos(arc_angle) + off_set_y, 0));
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, btnWid);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, btnLen);
            rt.rotation = rotation0;
            rt.Rotate(new Vector3(0, 0, 1), delt_angle * i);
        }
    }

    public void setText()
    {
       // clickCount++;
       
    }
    public void addAndSet()
    {
        clickCount++;
        setText();
    }
}
