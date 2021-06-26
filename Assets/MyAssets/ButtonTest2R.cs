using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonTest2R : MonoBehaviour {


	public Button[] btns;
	float clickCount = 0;

	public float btnWid;

	public float r;


	float pos_x, pos_y;
	float btnsSize;
	public static Quaternion rotation0;
	// Use this for initialization
	void Start()
	{
		setText();
		//rotation0 = btns[0].GetComponent<RectTransform>().rotation;
		btnsSize = btns.Length;
		//changeLayout();

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
		float max_angle = ButtonTest.max_angle;
		float btnLen = ButtonTest.btnLen;

		float alpha = ButtonTest.alpha;

		float delt_angle = max_angle / btnsSize;

        r = (float)(ButtonTest.r + btnLen + 1 + (1 - ButtonTest.blankRate) * btnWid);
        btnWid = (float)(r * max_angle / 180 * 3.1415926 / btnsSize*ButtonTest.blankRate);

		for (int i = 0; i < btnsSize; i++)
		{   
			//修改锚点
			btns[i].transform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,0,0);
			btns[i].transform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom,0,0);
			float arc_angle = (float)((DisplaySpin.off_spin_angle_in_degree+delt_angle * i) / 180 * 3.1415926);
			RectTransform rt = btns[i].GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(btnWid, btnLen);
			rt.position = (new Vector3(-(-r * (float)System.Math.Sin(arc_angle) )+20, r * (float)System.Math.Cos(arc_angle) + off_set_y, 0));
			rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, btnWid);
			rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, btnLen);
			rt.rotation = rotation0;
			rt.Rotate(new Vector3(0, 0, 1), delt_angle * (-i)- DisplaySpin.off_spin_angle_in_degree );
			Image img = btns[i].GetComponent<Image>();
			img.color = new Color(1, 1, 1, alpha);
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
