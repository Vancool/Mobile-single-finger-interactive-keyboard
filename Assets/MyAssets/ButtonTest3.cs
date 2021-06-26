using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest3 : MonoBehaviour
{
   // public Text text;
   // public Text editText;
    public Button[] btns;
    float clickCount = 0;
   
    public static float btnWid;

    public float r;

    public static float R3_minus_halfLen = 0;


    float pos_x, pos_y;
    float btnsSize;
   public static  Quaternion rotation0;
    // Use this for initialization
    void Start()
    {
        setText();
        rotation0 = btns[0].GetComponent<RectTransform>().rotation;
        btnsSize = btns.Length;
        changeLayout();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            changeLayout();
        }

    }
    public void changeLayout()
    {


      
        float off_set_x = ButtonTest.off_set_x, off_set_y = ButtonTest.off_set_y;
     float max_angle =ButtonTest.max_angle;
     float btnLen  = ButtonTest.btnLen;
        //r = ButtonTest.r -2*btnLen-2;
        float alpha = ButtonTest.alpha;

        float delt_angle = max_angle / btnsSize;

        btnWid = (float)(r * max_angle / 180 * 3.1415926 / btnsSize*ButtonTest.blankRate);
        r = (float)(ButtonTest.r +2* btnLen + 2 + 2*(1 - ButtonTest.blankRate) * btnWid);
        R3_minus_halfLen = r - ButtonTest.btnLen / 2;

        for (int i = 0; i < btnsSize; i++)
        {
            float arc_angle = (float)((DisplaySpin.off_spin_angle_in_degree+ delt_angle * i) / 180 * 3.1415926);
            RectTransform rt = btns[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(btnWid, btnLen);
            rt.position = (new Vector3(-r * (float)System.Math.Sin(arc_angle) + off_set_x, r * (float)System.Math.Cos(arc_angle) + off_set_y, 0));
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, btnWid);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, btnLen);
            rt.rotation = rotation0;
            rt.Rotate(new Vector3(0, 0, 1), delt_angle * i + DisplaySpin.off_spin_angle_in_degree);
            Image img = btns[i].GetComponent<Image>();
            img.color = new Color(1, 1, 1, alpha);
        }
    }

    public void setText()
    {
        // clickCount++;
        //text.text = "click count " + clickCount;
    }
    public void addAndSet()
    {
        clickCount++;
        setText();
    }
}
