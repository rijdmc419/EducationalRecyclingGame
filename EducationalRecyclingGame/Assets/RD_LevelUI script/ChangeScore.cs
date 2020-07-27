using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeScore : MonoBehaviour
{

    public Text Score;
    public Button bonus;
    int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainPoints()
    {
        points = points + 100;
        Score.text = points.ToString();
    }
}
