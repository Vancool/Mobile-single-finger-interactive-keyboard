﻿using UnityEngine;
using UnityEngine.UI;

public class IrregularButton : MonoBehaviour {

    public Text text;
    private int count;

	void Awake () {
        // 设置阈值
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.1f;

        count = 0;
	}

    public void OnButtonClicked() {
        count++;
        text.text = "第" + count + "次按下按钮";
    }
}
