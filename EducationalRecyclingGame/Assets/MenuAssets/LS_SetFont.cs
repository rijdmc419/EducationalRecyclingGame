using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LS_SetFont : MonoBehaviour {

    // instance variables
    public Font otherFont;
    public Color fontColor = new Color32(225, 188, 222, 255);

    // sets font to the font attached to the script
    public void SetFont(Font otherFont) {
    	SendInfo.myFont = otherFont;

    }

    
    void Start() {
        // only runs on the first scene
        if (SendInfo.myFont is null) {
            SetFont(otherFont);
        }

        // changes the font color of each text object in scene
    	var textObjects = FindObjectsOfType<Text>();
    	foreach (Text text in textObjects) {
    		text.font = SendInfo.myFont;
            text.color = fontColor;
    	}
    	
    }
}
