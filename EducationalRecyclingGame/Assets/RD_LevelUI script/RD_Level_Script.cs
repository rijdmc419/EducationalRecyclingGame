using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RD_Level_Script : MonoBehaviour {

	public Text levelText;
	public Text Score;

    public void GainPoints(int newPoints) {
        SendInfo.points += newPoints;
        Score.text = SendInfo.points.ToString();
    }

    void Start() {
        InvokeRepeating("ShowLevel", 0f, (float) SendInfo.NUMSECONDS);

    }

    void ShowLevel() {
    	levelText.text = "Level " + SendInfo.levelNumber.ToString();
    	if (SendInfo.levelNumber > 1) {
    		SendInfo.pointArray[SendInfo.levelNumber - 1] = SendInfo.points;
    		SendInfo.points = 0;
    		Score.text = SendInfo.points.ToString();
    	}
    }
    

    void OnCollisionEnter2D(Collision2D coll)
    {
    	if (coll.gameObject.tag == this.tag) {
    		GainPoints(10);
    	}
    	else {
    		GainPoints(-10);
    	}
    	
        Destroy(coll.gameObject);
        // Debug.Log("hit detected " + coll.gameObject.name);
       // if (coll.gameObject.name == "Bin")
        //{
        	
            // this.gameObject.SetActive(false);
        //}
        
    }    
}
