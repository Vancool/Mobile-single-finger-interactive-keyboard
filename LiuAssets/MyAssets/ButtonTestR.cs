using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTestR : MonoBehaviour {

	public Button[] btns;

	public static float blankRate = 0.85f; 
	float clickCount = 0;

	public float btnWid;

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

        /*
		off_set_x = ns_off_set_x;
		off_set_y = ns_off_set_y;
		max_angle = ns_max_angle;
		btnLen = ns_btnLen;
		
        */
        btnsSize = btns.Length;
        

	}
    void updateAttributes()
    {
        off_set_x = ButtonTest.off_set_x;
        off_set_y = ButtonTest.off_set_y;
        max_angle = ButtonTest.max_angle;
        btnLen = ButtonTest.btnLen;

        ButtonTest2R.rotation0 = ButtonTest2.rotation0;
        ButtonTest3R.rotation0 = ButtonTest3.rotation0;

    }

	// Update is called once per frame
	void Update () {
		
	}
	public void changeLayout()
	{


        updateAttributes();
        float delt_angle = max_angle / btnsSize;

		btnWid = (float)(r * max_angle / 180 * 3.1415926 / btnsSize*blankRate);

		for (int i = 0; i < btnsSize; i++)
		{
			//设置锚点
			btns[i].transform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,0,0);
			btns[i].transform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom,0,0);
			float arc_angle = (float)(delt_angle * i / 180 * 3.1415926);
			RectTransform rt = btns[i].GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(btnWid, btnLen);
			//位置变换
			rt.position = (new Vector3(-(-r * (float)System.Math.Sin(arc_angle) )+20, r * (float)System.Math.Cos(arc_angle) + off_set_y, 0));
			rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, btnWid);
			rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, btnLen);
			rt.rotation = rotation0;
			//变换角度
			rt.Rotate(new Vector3(0, 0, 1), delt_angle * (-i));


			//print ("Rotate");
		}
	}

	public void setText()
	{
		
	}
	public void addAndSet()
	{
		clickCount++;
		setText();
	}
}
