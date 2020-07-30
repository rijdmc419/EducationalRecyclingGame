using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAlignments : MonoBehaviour
{
    
    public GameObject AllUI;

    // Start is called before the first frame update
    void Start()
    {


        RectTransform background = AllUI.transform.Find("Background").GetComponent<RectTransform>();
        background.anchorMin = new Vector2(0.5f, 1f);
        background.anchorMax = new Vector2(0.5f, 1f);
        background.pivot = new Vector2(0.5f, 0.5f);
        //background.position = new Vector3(0f, -70f, 0f);
        background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 770);
        background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
