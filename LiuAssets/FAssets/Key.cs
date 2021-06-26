using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {
	public Text output=null;//输出文本
	int wordIndex=0;//光标位置
	string myString=null;//输出的全部文本
	string key;//输入的按键
	int lineIndex=0;//输入的行数
	bool isUP=true;


	public int R=400;
	public int divideUp = 1;//按键 上下
	public float divideAngle=1.0f;//按键左右(角度)
	public int size=30;//按键长度（垂直）
	public float  angle=60;//扇形角度
	//扇形中心点坐标
	public float x=190.0f;
	public float y=33.0f;
	//透明度
	public float alpha=0.5f;
	public Button[]button1;//最上行
	public Button[] button2;//中间
	public Button[] button3;//最下
	public Button[] special;//特殊按鍵
	public Texture countText;//计算一共点击的次数（用于计算
	public int countNum;

	//输入文本的函数
	public void alphabetFunction(string alphabet){
//		Debug.Log (wordIndex);
		wordIndex++;
		myString = myString + alphabet;
		output.text = myString;
	//	Debug.Log (wordIndex);
	}

	// Use this for initialization
	void Start () {
		countNum = 0;
		//output.text = "AB\n AB";
		//修改尺寸和位置
		changeTest();


	}

	// Update is called once per frame
	void Update () {

		//changeTest ();
	}
	//整个键盘布局以及注册
	void changeTest(){
		float keyLength = 0.0f;
		float TopSubAngle = 0.0f;
		if (button1.Length > 0) {
			//现在的旋转角
			keyLength = countLength (1, angle, divideAngle);
			TopSubAngle=(angle-(10+1)*divideAngle)/10.0f;
		} else {
			Debug.Log ("error ,none key!");
		}

		for (int i = 0; i < button1.Length; i++) {
			Button temp = button1 [i];
			button1 [i].onClick.AddListener (delegate() {
				this.alphabetFunction(temp.name);
			});
			button1 [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, size);
			button1 [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, size);
			Vector2 pos = countPosition (x, y, 1, i, divideUp, divideAngle, angle, size,0.0f);
			button1 [i].GetComponent<RectTransform> ().position = (new Vector3 (pos.x,pos.y, 0));
	//	//	float length=countLength(1,angle,divideAngle);
			button1 [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, keyLength);
		float curAngle = countRotate (1, i, angle, divideAngle);
		button1 [i].GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, -1), curAngle);
		button1 [i].transform.Find ("Text").GetComponent<Text> ().text = button1 [i].name;

		}
		for (int i = 0; i < button2.Length; i++) {
			Button temp = button2 [i];
			button2 [i].onClick.AddListener (delegate() {
				this.alphabetFunction(temp.name);
			});
			float padAngle = 0.0f;
			Debug.Log (padAngle);
			//	button2[i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, size);
			button2 [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, size);
			Vector2 pos = countPosition (x, y, 2, i, divideUp, divideAngle, angle, size,padAngle);
			button2 [i].GetComponent<RectTransform> ().position = (new Vector3 (pos.x,pos.y, 0));
			button2 [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, keyLength);
			float curAngle = countRotate (2, i, angle, divideAngle);
			button2[i].GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, -1), curAngle);
			button2 [i].transform.Find ("Text").GetComponent<Text> ().text = button2 [i].name;
		}
		for (int i = 0; i < button3.Length; i++) {
			Button temp = button3 [i];
			button3 [i].onClick.AddListener (delegate() {
				this.alphabetFunction(temp.name);
			});
			float padAngle = 0.0f;
			//	button3[i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, size);
			button3 [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, size);
			Vector2 pos = countPosition (x, y, 3, i, divideUp, divideAngle, angle, size,padAngle);
			button3[i].GetComponent<RectTransform> ().position =(new Vector3 (pos.x,pos.y, 0));
			button3 [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, keyLength);
			float curAngle = countRotate (3, i, angle, divideAngle);
			button3 [i].GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, -1), curAngle);
			button3[i].transform.Find ("Text").GetComponent<Text> ().text = button3 [i].name;
		}
		for (int i = 0; i < special.Length; i++) {
			float padAngle = 0.0f;
			//	button3[i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, size);
			special [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, size);
			Vector2 pos = countPosition (x, y, 4, i, divideUp, divideAngle, angle, size,padAngle);
			special[i].GetComponent<RectTransform> ().position =(new Vector3 (pos.x,pos.y, 0));
			special [i].GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, keyLength);
			float curAngle = countRotate (4, i, angle, divideAngle);
			special[i].GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, -1), curAngle);
			special[i].transform.Find ("Text").GetComponent<Text> ().text = special[i].name;
			Debug.Log (special [i].name);
		}
		special [0].onClick.AddListener (up_down);
	}
//添加大小写转换
	public void up_down(){
		if (isUP) {
			isUP = false;
			//Debug.Log ("hello?");
			for (int i = 0; i < button1.Length; i++) {
				string keyName = button1 [i].name;	
				button1 [i].name = keyName.ToLower ();
				button1 [i].transform.Find ("Text").GetComponent<Text> ().text = button1 [i].name;
			}
			for (int i = 0; i < button2.Length; i++) {
				string keyName = button2 [i].name;
				button2[i].name = keyName.ToLower ();
				button2[i].transform.Find ("Text").GetComponent<Text> ().text = button2 [i].name;
			}
			for (int i = 0; i < button3.Length; i++) {
				string keyName = button3 [i].name;
				button3[i].name = keyName.ToLower ();
				button3[i].transform.Find ("Text").GetComponent<Text> ().text = button3 [i].name;
			}
		} else {
			isUP = true;
			for (int i = 0; i < button1.Length; i++) {
				string keyName = button1 [i].name;
				button1 [i].name = keyName.ToUpper ();
				button1 [i].transform.Find ("Text").GetComponent<Text> ().text = button1 [i].name;
			}
			for (int i = 0; i < button2.Length; i++) {
				string keyName = button2 [i].name;
				button2[i].name = keyName.ToUpper ();
				button2[i].transform.Find ("Text").GetComponent<Text> ().text = button2 [i].name;
			}
			for (int i = 0; i < button3.Length; i++) {
				string keyName = button3 [i].name;
				button3[i].name = keyName.ToUpper ();
				button3 [i].transform.Find ("Text").GetComponent<Text> ().text = button3 [i].name;
			}
		}
	}
	public float countPadding(int keyNum,float angle,float divideAngle,float topAngle){

	
		float padAngle = angle - (keyNum - 1) * divideAngle - keyNum * topAngle;
		padAngle = padAngle / 2.0f;
		//Debug.Log (padAngle);
		if (keyNum == 9) {
			Debug.Log (topAngle);
			Debug.Log(divideAngle);
			Debug.Log (angle);
			Debug.Log (padAngle);
			Debug.Log (padAngle * 2 + keyNum * topAngle + (keyNum - 1) * divideAngle);
		}
		if (padAngle >= 0.0f)
			return padAngle;
		else
			return 0.0f;
	}
	public Vector2  countPosition(float x,float y,int level,int index,int divideUp,float divideAngle,float Angle,int size,float padAngle){
		//index从零开始
		//按键底边
		float currentR = R - level * divideUp-(level-1)*size-size/2.0f;
		if (currentR <= 0) {
			Debug.Log ("error current R");
		}
		int keyNum = 0;
		if (level == 1) {
			keyNum = 10;
		} else if (level == 2) {
			keyNum = 9;
		} else if (level == 3) {
			keyNum = 7;
		} else {
			keyNum = 3;
//			return 0.0f;
		}
		//每个按键的角度
		float subAngle=(Angle-(keyNum+1)*divideAngle)/keyNum;
		//按键和垂直边的角度
		float theta = (divideAngle * (index + 1)) + subAngle * index+subAngle/2.0f+padAngle;

		float posX = x + currentR * Mathf.Sin (theta * Mathf.PI / 180);//好像是弧度制的
		float posY= y+currentR*Mathf.Cos(theta*Mathf.PI/180);
		return new Vector2 (posX, posY);
	}
	//计算按键的长度（水平）
	public float countLength(int level,float Angle,float divideAngle){
		float currentR = R - level * divideUp-(level-1)*size-size;
		if (currentR <= 0) {
			Debug.Log ("error current R");
		}
		int keyNum = 0;
		if (level == 1) {
			keyNum = 10;
		} else if (level == 2) {
			keyNum = 9;
		} else if (level == 3) {
			keyNum = 7;
		} else  {
			keyNum = 3;
		}
		//每个按键的角度
		float subAngle=(Angle-(keyNum+1)*divideAngle)/keyNum;
		//按键的长度
		float subLen=2*Mathf.PI*currentR*subAngle/360;
		return subLen;
	}
	//计算按键旋转的角度
	public float countRotate(int level,int index,float Angle,float divideAngle){
		int keyNum = 0;
		if (level == 1) {
			keyNum = 10;
		} else if (level == 2) {
			keyNum = 9;
		} else if (level == 3) {
			keyNum = 7;
		} else if (level == 4) {
			keyNum = 3;
			//			return 0.0f;
		} else {
			Debug.Log ("error..");
		}
		//每个按键的角度
		float subAngle=(Angle-(keyNum+1)*divideAngle)/keyNum;
		float currentAngle = divideAngle * index + (index - 1) * subAngle;
		return  currentAngle;
	}
}

