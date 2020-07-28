using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_Collision : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Debug.Log("hit detected " + coll.gameObject.name);
        if (coll.gameObject.name == "Bin")
        {
            Destroy(this.gameObject);
            // this.gameObject.SetActive(false);
        }
        
    }
}