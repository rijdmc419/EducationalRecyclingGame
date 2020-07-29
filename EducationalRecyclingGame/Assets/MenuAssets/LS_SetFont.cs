using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LS_SetFont : MonoBehaviour {

    public Font otherFont;
    public Color fontColor = new Color32(225, 188, 222, 255);

    public void SetFont(Font otherFont) {
    	SendInfo.myFont = otherFont;
    }

    
    void Start() {
        if (SendInfo.myFont is null) {
            SetFont(otherFont);
        }
    	var textObjects = FindObjectsOfType<Text>();
    	foreach (Text text in textObjects) {
    		text.font = SendInfo.myFont;
            text.color = fontColor;
    	}
    	
    }
}
