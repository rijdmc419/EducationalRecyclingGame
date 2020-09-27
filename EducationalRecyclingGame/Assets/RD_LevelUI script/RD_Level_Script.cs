using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RD_Level_Script : MonoBehaviour {

	public Text levelText;
	public Text Score;

    void Start() {
        // ensures that items don't collide with each other
        ShowLevel();
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(8, 11);
        Physics2D.IgnoreLayerCollision(10, 10);

    }

    public void ShowLevel() {
        // shows the level every time it switches
        // also sets the points to zero once the user switches level
        levelText.text = "Level " + SendInfo.levelNumber.ToString();

        Score.text = SendInfo.points.ToString();

    }

    public void GainPoints(int newPoints) {
    	// adds points to the score
        SendInfo.points += newPoints;
        Score.text = SendInfo.points.ToString();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        // adds or subtracts points based on the collision
        // of 2 objects

        if (BoolExpressionByLevel(SendInfo.levelNumber, coll)) {
            GainPoints(10);
        }
        else {
            GainPoints(-10);
        }
        
        Destroy(coll.gameObject);

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
