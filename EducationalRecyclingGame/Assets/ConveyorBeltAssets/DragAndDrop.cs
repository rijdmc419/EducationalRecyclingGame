using System.Collections;
using UnityEngine;

class DragAndDrop : MonoBehaviour
{
    private Color mouseOverColor = Color.red;
    private Color originalColor = Color.green;
    private bool dragging = false;
    private float distance;
    private Vector3 startDist;


    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDist;
        }
    }

    //  void OnCollisionEnter2D(Collision2D coll) {
    //     // ignores physics if collides with another item

    //     if (coll.gameObject.layer == 8) {
    //         Physics.IgnoreCollision(this.collider, coll.collider);
    //     }
        
    //     Destroy(coll.gameObject);

    // }
}