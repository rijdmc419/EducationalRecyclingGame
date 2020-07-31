using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAlignments : MonoBehaviour
{
    public GameObject LevelUICanvas;
    public GameObject PauseCanvas;
    public GameObject NextCanvas;

    // Start is called before the first frame update
    void Start()
    {


        RectTransform background = LevelUICanvas.transform.Find("Background").GetComponent<RectTransform>();
        background.anchorMin = new Vector2(0.5f, 1f);
        background.anchorMax = new Vector2(0.5f, 1f);
        background.pivot = new Vector2(0.5f, 0.5f);
        background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1400);
        background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 130);

        RectTransform Pause_background = PauseCanvas.transform.Find("Pause Background").GetComponent<RectTransform>();
        background.anchorMin = new Vector2(0.5f, 0.5f);
        background.anchorMax = new Vector2(0.5f, 0.5f);
        background.pivot = new Vector2(0.5f, 0.5f);
        background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1740);
        background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 930);

        RectTransform Complete_background = NextCanvas.transform.Find("Complete Background").GetComponent<RectTransform>();
        background.anchorMin = new Vector2(0.5f, 0.5f);
        background.anchorMax = new Vector2(0.5f, 0.5f);
        background.pivot = new Vector2(0.5f, 0.5f);
        background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1340);
        background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 740);


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
