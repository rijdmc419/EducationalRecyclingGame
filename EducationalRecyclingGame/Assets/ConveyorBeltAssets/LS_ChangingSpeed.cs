using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_ChangingSpeed : MonoBehaviour
{
    // obj is the conveyor belt
    public GameObject obj;

    // instance variables
    int level = 1;
    float speed = -2f;
    float conveyorVelocity;
    SurfaceEffector2D se;

    void Start() {

        // gets SurfaceEffector 2D of object
    	se = obj.GetComponent<SurfaceEffector2D>();

        if (se == null) {
            obj.AddComponent<SurfaceEffector2D>();
            se = obj.GetComponent<SurfaceEffector2D>();
        }

        ChangeSpeed();

    }

    public void ChangeSpeed() {
        // adjusts speed of conveyor belt after level 5

    	level = SendInfo.levelNumber;
    	
    	if (level > 5) {
    		speed = (level-2) * -1f;
    	}
    	
    	se.speed = speed;
    	se.forceScale = 0.1f;


    }
}
