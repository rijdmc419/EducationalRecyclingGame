using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_ConveyorBelt : MonoBehaviour
{
    // Start is called before the first frame update
    int level = 1;
    float speed = -2f;
    float conveyorVelocity;
    public GameObject obj;
    SurfaceEffector2D se;

    void Start() {
    	obj.AddComponent<SurfaceEffector2D>();
    	se = obj.GetComponent<SurfaceEffector2D>();
        InvokeRepeating("LevelChange", 0f, 1f);
    }

    // Update is called once per frame
    public void LevelChange() {
    	if (level!=SendInfo.levelNumber) {
    		ChangeSpeed();
    	}
    }

    void ChangeSpeed() {
    	level = SendInfo.levelNumber;
    	
    	if (level > 5) {
    		speed = (level-2) * -1f;
    	}
    	
    	se.speed = speed;
    	se.forceScale = 0.1f;


    }
}
