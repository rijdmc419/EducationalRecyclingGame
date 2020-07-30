using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("hit detected");
        if (coll.gameObject.name == "Bin")
        {
            Destroy(this.gameObject);
        }
        this.gameObject.SetActive(false);
        
    }
}