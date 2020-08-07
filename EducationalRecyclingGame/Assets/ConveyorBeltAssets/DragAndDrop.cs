using System.Collections;
using UnityEngine;

class DragAndDrop : MonoBehaviour
{
    private Color mouseOverColor = Color.green;
    private Color stock = Color.white;
    private bool dragging = false;
    private float distance;
    private Vector3 startDist;

    void OnMouseDown()
    {
        // GetComponent<Renderer>().material.color = mouseOverColor;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
    }

    void OnMouseUp()
    {
        GetComponent<Renderer>().material.color = stock;      
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

}   