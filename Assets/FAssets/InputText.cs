using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputText : MonoBehaviour {
    public Text myOutput;
    public InputField tooutput;
    public static Text output = null;//输出文本
    static int wordIndex = 0;//全部字符数量
   static int wordPosition = 0;//光标的位置
    static int wordCount = 0;//输入的字符数计算
   public static string myString = null;//输出的全部文本
    string key;//输入的按键
    public Button[] button1;//最上行
    public Button[] button2;//中间
    public Button[] button3;//最下
    public Button[] special;//特殊按鍵
                            // Use this for initialization
    void Start () {
        output = myOutput;
        //output = tooutput;
        changeTest();
	}
    //输入文本的函数
    public void alphabetFunction(string alphabet)
    {
        if (Controler.changingLayOutByGesture) return;

        wordIndex++;
        wordCount++;
        wordPosition++;
        myString = myString + alphabet;
        //output.ActivateInputField();
        //output.caretPosition = 0;
        output.text = myString;
        // //output.selectionAnchorPosition = wordIndex-2;
        // output.selectionFocusPosition = wordIndex-1;
        //output.Select();
        //print( output.IsActive());
        
        //output.text = "haha";

       // int a = output.selectionAnchorPosition;
        //int b = output.selectionFocusPosition;
        //output.selectionAnchorPosition = output.selectionFocusPosition;
       // output.Select();
        //output.MoveTextEnd(true);

   
     
    }

    void changeTest() {
        for (int i = 0; i < button1.Length; i++)
        {
            Button temp = button1[i];
            button1[i].onClick.AddListener(delegate () {
                this.alphabetFunction(temp.name);
            });
        }
        for (int i = 0; i < button2.Length; i++)
        {
            Button temp = button2[i];
            button2[i].onClick.AddListener(delegate () {
                this.alphabetFunction(temp.name);
            });
        }
        for (int i = 0; i < button3.Length; i++)
        {
            Button temp = button3[i];
            button3[i].onClick.AddListener(delegate () {
                this.alphabetFunction(temp.name);
            });
 
        }
        
            special[0].onClick.AddListener(backspace);
        
 
        
        special[1].onClick.AddListener(typeEnter);
        special[2].onClick.AddListener(typeSpace);

     
    }
    public static void backspace()
    {
        if (Controler.changingLayOutByGesture) return;

        if (wordIndex > 0)
        {
            Debug.Log(myString);
            myString = myString.Remove(wordIndex - 1);
            wordIndex--;
            output.text = myString;
    
        }		
	}
    public void typeEnter()
    {
        if (Controler.changingLayOutByGesture) return;
        wordIndex +=2;
        wordCount+=2;
        wordPosition+=2;
        myString += "\r\n";  
        output.text = myString;
    }
    public void typeSpace()
    {
        if (Controler.changingLayOutByGesture) return;
        wordIndex++;
        wordCount++;
        wordPosition++;
        myString += " ";
        output.text =myString;
    }
    public static void  input(string str)
    {
        if (Controler.changingLayOutByGesture) return;
        myString += str;
        wordCount += str.Length;
        wordIndex += str.Length;
        wordPosition += str.Length;
        output.text = myString;
    }
  
}
