using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RD_Level_Script : MonoBehaviour {

	public Text levelText;

    void Start() {
        levelText.text = "Level " + SendInfo.levelNumber.ToString();
  
    }
}
