using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controler : MonoBehaviour {
    public float max_angle , min_angle;
    public float max_off_x, min_off_x, max_off_y, min_off_y;
    public float max_btn_len, min_btn_len;
    public float deltMinOffY;
    public GameObject floor4;//第四层
    private BtnTestArc btnta;
    private BtuTestArcR btnar;
    private bool reverses = true;
    public static bool changingLayOutByGesture = false;

    public GameObject InputText;

    public Button[] adjustBtns;
    public Slider adjustAlphaSlider;
    public Text alphaText;

	// Use this for initialization
	void Start () {
        btnta = floor4.GetComponent<BtnTestArc>();
        btnar = floor4.GetComponent<BtuTestArcR>();

       

	}
    Vector2 start;
    float x_Speed = 1;
    float y_Speed = 1;

    float timer = 0;
    // Update is called once per frame
    void Update () {

        if (timer <= 0.01)
        {
            print("timer<0.2");
            timer += Time.deltaTime;
            if (timer >= 0.01)
            {
                changeLayout();
                changingLayOutByGesture = true;
                setSetState();
                print("Chnage");
            }
        }
        // 改变布局
        if (changingLayOutByGesture)
        {
            if (Input.touchCount == 0)
            {
                return;
            }
            if (Input.touchCount == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    start = Input.touches[0].position;


                }

                if (Input.touches[0].phase == TouchPhase.Moved)
                {
                    float mx = Input.touches[0].deltaPosition.x * x_Speed;
                    float my = Input.touches[0].deltaPosition.y * y_Speed;

                    //ButtonTest.off_set_x += (int)mx;
                    changeOffX(mx);
                    //ButtonTest.off_set_y += (int)my;
                    changeOffY(my);
                    changeLayout();

                }

                //transform.rotation = mRoation;




            }
            else if (Input.touchCount == 2)
            {
                if (Input.touches[0].phase == TouchPhase.Began || Input.touches[1].phase == TouchPhase.Began)
                {
                    start.x = System.Math.Abs(Input.touches[0].position.x - Input.touches[1].position.x);
                    start.y = System.Math.Abs(Input.touches[0].position.y - Input.touches[1].position.y);
                }
                else if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
                {
                    float e_x = System.Math.Abs(Input.touches[0].position.x - Input.touches[1].position.x);
                    float e_y = System.Math.Abs(Input.touches[0].position.y - Input.touches[1].position.y);

                    float c_a = e_x - start.x;
                    float c_r = e_y - start.y;
                    if (System.Math.Abs(c_a) > System.Math.Abs(c_r))
                    {
                        changeMaxAngle(System.Math.Sign(c_a));

                    }
                    if (System.Math.Abs(c_a) < System.Math.Abs(c_r))
                    {
                        changeBtnLen(System.Math.Sign(c_r));
                    }
                    start.x = e_x;
                    start.y = e_y;

                    //ButtonTest.btnLen += System.Math.Sign(e_y - start.y);
                    changeLayout();

                }
            }
        }
        else
        {
            //其他手势情况




        }

    }

    public void  changeLayout()
    {
        if (AdjustAlpha.changingAlpha) return;
        if (reverses)
        {
            GetComponent<ButtonTest>().changeLayout();
            GetComponent<ButtonTest2>().changeLayout();
            GetComponent<ButtonTest3>().changeLayout();
            btnta.changeLayout(ButtonTest.max_angle, ButtonTest.blankRate, ButtonTest.btnLen, ButtonTest.r - ButtonTest.btnLen - (1 - ButtonTest.blankRate) * ButtonTest.btnWid, ButtonTest.off_set_x, ButtonTest.off_set_y, ButtonTest.alpha);
        }
        else {
            GetComponent<ButtonTestR>().changeLayout();
            GetComponent<ButtonTest2R>().changeLayout();
            GetComponent<ButtonTest3R>().changeLayout();
            btnar.changeLayout(ButtonTest.max_angle, ButtonTest.blankRate, ButtonTest.btnLen, ButtonTest.r - ButtonTest.btnLen - (1 - ButtonTest.blankRate) * ButtonTest.btnWid, ButtonTest.off_set_x, ButtonTest.off_set_y, ButtonTest.alpha);
        }
    }

    bool[] flag = new bool[5];

   public  void setupAndDowFlag()
    {
        for (int i = 0; i < 5; i++)
            flag[i] = false;
        flag[0] = true;
    }

    public void setLeftAndRightFlag()
    {
        for (int i = 0; i < 5; i++)
            flag[i] = false;
        flag[1] = true;
    }
   public  void setRFlag()
    {
        for (int i = 0; i < 5; i++)
            flag[i] = false;
        flag[2] = true;
    }

    public void setAngleFlag()
    {
        for (int i = 0; i < 5; i++)
            flag[i] = false;
        flag[3] = true;
    }
    public void setLenFlag()
    {
        for (int i = 0; i < 5; i++)
            flag[i] = false;
        flag[4] = true;
    }

    public void addData()
    {
        int k = -1;
        for (int i = 0; i < 5; i++)
            if (flag[i])
            {
                k = i;
                break;
            }
        switch (k)
        {
            case -1:
                return;
            case 0:
                changeOffY(10);
                break;
            case 1:
                changeOffX(10);
                //ButtonTest3.R3_minus_halfLen+=
                break;
            case 2:
                changeBtnR(1);
                break;

            case 3:
                changeMaxAngle(1);
                break;
            case 4:
                changeBtnLen(1);

                //float r3 = ButtonTest3.R3_minus_halfLen + ButtonTest.btnLen;
                //r = (float)(ButtonTest.r -2* btnLen - 2 - 2*(1 - ButtonTest.blankRate) * btnWid);
                //ButtonTest.r = r3 + 2 * ButtonTest.btnLen + 2 + 2 * (1 - ButtonTest.blankRate) * ButtonTest3.btnWid;
               
                break;
        }
        changeLayout();
       
    }

    private void changeMaxAngle(float delt_angle)
    {
        if (ButtonTest.max_angle >= max_angle && delt_angle > 0 || ButtonTest.max_angle <= min_angle && delt_angle < 0) return;
        ButtonTest. max_angle += delt_angle;

        float max_Angle_by_arc = (float)((90-ButtonTest.max_angle) * 3.14159 / 180);

        float h = (float)System.Math.Sin(max_Angle_by_arc)*ButtonTest.r;

        min_off_y = -h+deltMinOffY;

    }

    private void changeBtnR(float deltR)
    {
        
        
            float angle_0_5 = (float)(ButtonTest.max_angle / 2 * 3.14159 / 180);
            ButtonTest.off_set_x += (float)(System.Math.Sin(angle_0_5) * deltR);
            ButtonTest.off_set_y -= (float)(System.Math.Cos(angle_0_5) * deltR);
        
       
    }

    private void changeOffY(float delt_off_y)
    {
        if (ButtonTest.off_set_y <= min_off_y && delt_off_y <= 0 || ButtonTest.off_set_y >= max_off_y && delt_off_y >= 0)
            return;
        ButtonTest.off_set_y += delt_off_y;
    }

    private void changeOffX(float delt_off_x)
    {
        if (ButtonTest.off_set_x <= min_off_x && delt_off_x <= 0 || ButtonTest.off_set_x >= max_off_x && delt_off_x >= 0)
            return;
        ButtonTest.off_set_x += delt_off_x;
    }

    private void changeBtnLen(float deltLen)
    {
        if (ButtonTest.btnLen >= max_btn_len &&deltLen>0 || ButtonTest.btnLen <= min_btn_len &&deltLen<0) return;

        ButtonTest.btnLen += deltLen;
         deltLen = deltLen / 2;
        {
            float angle_0_5 = (float)(ButtonTest.max_angle / 2 * 3.14159 / 180);
            ButtonTest.off_set_x -= (float)(System.Math.Sin(angle_0_5) * deltLen);
            ButtonTest.off_set_y += (float)(System.Math.Cos(angle_0_5) * deltLen);
        }
    }

    public void reduceData()
    {
        int k = -1;
        for (int i = 0; i < 5; i++)
            if (flag[i])
            {
                k = i;
                break;
            }

        switch (k)
        {
            case -1:
                return;
            case 0:
                changeOffY(-10);
                break;
            case 1:
                changeOffX(-10);
                break;
            case 2:
                changeBtnR(-1);
                break;
            case 3:
                changeMaxAngle(-1);
                break;
            case 4:
                changeBtnLen(-1);
                break;
        }
        changeLayout();
       
    }

    public void setSetState()
    {
        changingLayOutByGesture = !changingLayOutByGesture;
        if (changingLayOutByGesture)
        {
            alphaText.gameObject.SetActive(true);
            adjustAlphaSlider.gameObject.SetActive(true);
            for (int i = 0; i < adjustBtns.Length; i++)
            {
                adjustBtns[i].gameObject.SetActive(true);

            }
        }

        else
        {
            alphaText.gameObject.SetActive(false);
            adjustAlphaSlider.gameObject.SetActive(false);
            for (int i = 0; i < adjustBtns.Length; i++)
            {
                adjustBtns[i].gameObject.SetActive(false);

            }
        }


    }
    public void revers() {
        if (Controler.changingLayOutByGesture)
        {


        reverses =! reverses;
        changeLayout();
        }
    }
}
