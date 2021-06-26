using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gesture : MonoBehaviour {
	public float minSwipeDistY;

	public float minSwipeDistX;
    public Text mtex;
	private Vector2 startPos;
	
	public float offsetTime = 3.0f;//双击的时间间隔
	private float timer=0.0f;
	private int count=0;
	private bool tim=false;
    public static bool activategesture = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Controler.changingLayOutByGesture) { return; }
        else
        {
            if (tim == true)
            {
                timer += Time.deltaTime;

            }
            if (Input.touchCount > 0)

            {

                Touch touch = Input.touches[0];
                if (touch.tapCount == 2)
                {

                    DoubleT();
                }
                if (touch.tapCount == 1)
                {

                    ;
                }


                switch (touch.phase)

                {

                    case TouchPhase.Began:

                        startPos = touch.position;
                        //tim = true;
                        //count += 1;
                        break;



                    case TouchPhase.Ended:

                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                        float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                        /*
                        if (timer > offsetTime) {
                            timer = 0.0f;
                            count = 0;
                            tim = false;
                        }
                        if(count==2&timer<offsetTime){
                            DoubleT ();
                            timer = 0.0f;
                            count = 0;
                            tim = false;
                        }*/
                        if (swipeDistVertical > swipeDistHorizontal & swipeDistVertical > minSwipeDistY)

                        {
                            activategesture = true;
                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                            if (swipeValue > 0)//up swipe

                                Jump();

                            else if (swipeValue < 0)//down swipe

                                Shrink();

                        }



                        if (swipeDistHorizontal > swipeDistVertical & swipeDistHorizontal > minSwipeDistX)

                        {
                            activategesture = true;
                            float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                            if (swipeValue > 0)//right swipe

                                MoveRight();

                            else if (swipeValue < 0)//left swipe

                                MoveLeft();

                        }
                        else { activategesture = false; }
                        break;
                }
            }
        }
    }
	void Jump(){
        
        InputText.input(".");
	}
	void  Shrink(){
		
        InputText.input("\r\n");
	}
	void MoveRight(){
		
        InputText.input(" ");
	}
	void MoveLeft(){

        InputText.backspace();
	}
	void DoubleT(){
		
        //InputText.input("\r\n");
	}
}
