using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySpin : MonoBehaviour {

   public static float off_spin_angle_in_degree = 0;
   public static float off_spin_angle_in_arc = 0;

    //display state
    bool hidden = false;
    bool showing = true;
    bool changingState = false;

    private Controler contl;

    float idle_timer = 0;
    public float IdleTimeOut;//IdleTimeout空闲时间后 ， 变为display=false;
    public float process_delay;//delay秒后会完全消失

	// Use this for initialization
	void Start () {
        contl = GetComponent<Controler>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (hidden)
            {
                changingState = true;
            }
            idle_timer = 0;
        }

        if (Input.touchCount >= 1)
        {
            if (hidden)
            {
                changingState = true;
            }
            idle_timer = 0;
        }else if(!changingState&&showing)
        {
            idle_timer += Time.deltaTime;
            if (idle_timer >= IdleTimeOut)
            {
                //showing = false;
                changingState = true;
            }
        }

        if (showing&&changingState)
        {
            //隐藏动画
            off_spin_angle_in_degree -= 90f / (process_delay / Time.deltaTime);

            contl.changeLayout();

        }
        if (hidden && changingState)
        {
            //显示动画
            off_spin_angle_in_degree += 90f / (process_delay / Time.deltaTime);

            contl.changeLayout();
        }

        if(off_spin_angle_in_degree <-90)
        {
            showing = false;
            hidden = true;
            changingState = false;
            off_spin_angle_in_degree = -90;
        }
        if (off_spin_angle_in_degree > 0)
        {
            showing = true;
            hidden = false;
            changingState = false;
            off_spin_angle_in_degree = 0;
            idle_timer = 0;

        }

		
	}
}
