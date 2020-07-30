using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBin : MonoBehaviour
{
    public GameObject Bin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit detected");
        GameObject e = Instantiate(Bin) as GameObject;
        e.transform.position = transform.position;
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
    }
}