using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostsScript : MonoBehaviour
{
    
    public int registerKeyPress;
    public int amountOfPressed;
    int level = 0;

    void Start()
    {
        EnableBoosts();
    }


    public void EnableBoosts() {
    	if (this.name == "Freeze") { level = 6; }
        if (this.name == "Magnet") { level = 7; }

    	if (SendInfo.levelNumber < level) {
    		this.gameObject.SetActive(false);
    	} 
    	else {
    		this.gameObject.SetActive(true);
    		Reset();
    	}
    }

    void Reset() {
        this.GetComponent<Button>().interactable = true;
        registerKeyPress = 3; amountOfPressed = 0;

        this.GetComponentInChildren<Text>().text = this.name + " " +
                (registerKeyPress-amountOfPressed).ToString() + " Presses Left.";
    }

    public void CheckLimit()
    {
        amountOfPressed++;     
        this.transform.GetComponentInChildren<Text>().text = this.name + " " + 
            (registerKeyPress-amountOfPressed).ToString() + " Presses Left.";
        if (amountOfPressed == registerKeyPress) {
            this.GetComponent<Button>().interactable = false;
        }
    }

    public int AmountPressed() {
        return amountOfPressed;
    }


}
