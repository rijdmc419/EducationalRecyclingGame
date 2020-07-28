using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RD_Level_Script : MonoBehaviour {

	public Text levelText;
	public Text Score;
    int points = 0;

    public void GainPoints(int newPoints) {
        points = points + newPoints;
        Score.text = points.ToString();
    }

    void Start() {
        levelText.text = "Level " + SendInfo.levelNumber.ToString();
  
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Debug.Log("hit detected " + coll.gameObject.name);
       // if (coll.gameObject.name == "Bin")
        //{
        	GainPoints(10);
            Destroy(coll.gameObject);
            // this.gameObject.SetActive(false);
        //}
        
    }    
}
