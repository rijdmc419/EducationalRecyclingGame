using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll) {
    // adds or subtracts points based on the collision
    // of 2 objects

    	Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>());

    	StartCoroutine(Move(coll));
	    	

	}

	IEnumerator Move(Collision2D coll) {

    	float step;

    	while (Vector2.Distance(coll.transform.position, this.transform.position) > 0) {
    		step = 40*Time.deltaTime;
    		coll.transform.position = Vector2.MoveTowards(coll.transform.position, this.transform.position, step);
    		yield return new WaitForEndOfFrame();
    	}

        
        

    

    }
        
}
