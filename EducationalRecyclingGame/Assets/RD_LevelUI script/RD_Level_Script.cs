using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RD_Level_Script : MonoBehaviour {

	public Text levelText;
	public Text Score;

    public void GainPoints(int newPoints) {
    	// adds points to the score
        SendInfo.points += newPoints;
        Score.text = SendInfo.points.ToString();
    }

    void Start() {
        InvokeRepeating("ShowLevel", 0f, (float) SendInfo.NUMSECONDS);

    }

    void ShowLevel() {
    	// shows the level every time it switches
    	// also sets the points to zero once the user switches level
    	levelText.text = "Level " + SendInfo.levelNumber.ToString();
    	if (SendInfo.levelNumber > 1) {
    		SendInfo.pointArray[SendInfo.levelNumber - 1] = SendInfo.points;
    		SendInfo.points = 0;
    		Score.text = SendInfo.points.ToString();
    	}
    }

    void OnCollisionEnter2D(Collision2D coll) {
        // adds or subtracts points based on the collision
        // of 2 objects
        // Debug.Log("hit detected " + coll.gameObject.name);

        if (BoolExpressionByLevel(SendInfo.levelNumber, coll)) {
            GainPoints(10);
        }
        else {
            GainPoints(-10);
        }
        
        Destroy(coll.gameObject);
        
       // if (coll.gameObject.name == "Bin")
        //{
            
            // this.gameObject.SetActive(false);
        //}
        
    }

    bool BoolExpressionByLevel(int level, Collision2D c) {
        // returns if the collision should gain or lose points
        // based on the level

        if (c.gameObject.tag == this.tag) { return true; }
  
        if(c.gameObject.tag == Constants.TAG_MULTIPLE) { return false; }

        var levelBins = SendInfo.binArray;

        if (this.tag == "Recycling"
            && !levelBins.Contains(c.gameObject.tag)) { return true; }

        return false;
    }   


    



}
