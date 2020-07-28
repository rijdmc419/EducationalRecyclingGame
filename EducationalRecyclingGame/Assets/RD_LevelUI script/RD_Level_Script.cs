using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RD_Level_Script : MonoBehaviour {

	public Text levelText;
	public Text Score;
    public Button bonus;
    int points = 0;

    public void GainPoints()
    {
        points = points + 100;
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
        	points += 10;
        	Score.text = points.ToString();
            Destroy(coll.gameObject);
            // this.gameObject.SetActive(false);
        //}
        
    }    
}
