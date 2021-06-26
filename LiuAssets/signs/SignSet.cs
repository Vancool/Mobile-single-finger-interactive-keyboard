using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignSet : MonoBehaviour {

    public Button[] bs;
    private  Button[] btns;
    private bool sign = false;
    public  char[] signSet= {
        '0','9','8','7','6','5','4','3','2','1',
            '-','+','=',';','/',':','\'','"',',','.','?',
         '~','!','@',')','(','%','^','&','*','('
    };

    public  char[] letterSet =
    {
        'P','O','I','U','Y','T','R','E','W','Q',
        'L','K','J','H','G','F','D','S','A',
        'M','N','B','V','V','C','X','Z'
    };
    bool upcase = true; 
    
	// Use this for initialization
	void Start () {
        btns = bs;
        changeUpcase();

	}
    public  void setSign( )
    {
        for (int i = 0; i < btns.Length && i < signSet.Length; i++)
        {
            btns[i].GetComponentInChildren<Text>().text =""+ signSet[i];
            btns[i].name = "" + signSet[i];
        }
    }
    public   void setLetter()
    {
        for (int i = 0; i < btns.Length && i < signSet.Length; i++)
        {
            btns[i].GetComponentInChildren<Text>().text = "" + letterSet[i];
            btns[i].name= "" + letterSet[i];
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    public void changeSign()
    {
        if (sign)
        {
            setLetter();
        }else
        {
            setSign();
        }
        sign = !sign;
    }
    public void  changeUpcase()
    {
        if (sign) return;
        if(upcase)
        for (int i = 0; i < btns.Length; i++)
        {
                btns[i].name = btns[i].name.ToLower();
                btns[i].GetComponentInChildren<Text>().text = btns[i].name;
                int fs = btns[i].GetComponentInChildren<Text>().fontSize;
                int size = (int)ButtonTest.btnLen;
               
                btns[i].GetComponentInChildren<Text>().fontSize =(int) (ButtonTest.btnLen*0.7);
                letterSet[i] = btns[i].name[0];
            }
        else
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].name = btns[i].name.ToUpper();
                
                btns[i].GetComponentInChildren<Text>().text = btns[i].name;
                btns[i].GetComponentInChildren<Text>().fontSize = (int)(ButtonTest.btnLen*0.7);
                letterSet[i] = btns[i].name[0];
            }
        upcase = !upcase;
        
    }
    
}
