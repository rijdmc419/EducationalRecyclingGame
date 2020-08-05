using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnableBoosts();
    }


    public void EnableBoosts() {
    	int level = 0;
    	if (this.name == "FreezeButton") { level = 6; }

    	if (SendInfo.levelNumber < level) {
    		this.gameObject.SetActive(false);
    	}
    	else {
    		this.gameObject.SetActive(true);
    	}
    }
}
