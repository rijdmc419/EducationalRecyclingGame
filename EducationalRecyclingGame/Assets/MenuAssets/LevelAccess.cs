using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAccess : MonoBehaviour
{
    // Start is called before the first frame update
    string access = "";

    void Start()
    {
    	// disables/enables buttons as need be
    	DisableButtons(SendInfo.seeAllLevels);
    }

    // Update is called once per frame
    void Update() {

    	// takes in input string every frame
		foreach(char c in Input.inputString) {
    		access += c;
    	}

    	// checks if total input contains "trash"
    	// enables all buttons
        if (access.ToLower().Contains("trash")) {
        	access = "";
        	SendInfo.seeAllLevels = true;
        	DisableButtons(true);
        }

        // checks if total input contains exit
        // and bool seeAllLevels is already set to true
        // disables buttons accordingly
        if (access.ToLower().Contains("exit")
        		&& SendInfo.seeAllLevels == true) {
        	access = "";
        	SendInfo.seeAllLevels = false;
        	DisableButtons(false);
        }

    }

    void DisableButtons(bool trash) {

    	int buttonNumber;
    	// gets all buttons that are chilcren of the canvas
    	Button[] childrenList = this.GetComponentsInChildren<Button>();

    	// iterates through childrenList, catching Back and Menu buttons
    	foreach (var i in childrenList) {
    		try {
    			buttonNumber = Int32.Parse(i.name);
	    		
	    		// changes interactability of buttons
	    		// based on the state of parameter trash
	    		if (!trash) {
	    			if (buttonNumber > SendInfo.highestLevel) {
    				i.interactable = false;
    				}
	    		}
	    		else {
	    			i.interactable = true;
	    		}
    			
    		}
    		catch (FormatException e) {}
    	}

    }
}
