using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LS_SetFont : MonoBehaviour {
    
    public Font otherFont;

    void Start() {
    	var textObjects = FindObjectsOfType<Text>();
    	foreach (Text text in textObjects) {
    		text.font = otherFont;
    	}
    	
    }
}
