using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleStart : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject toggle;

    void Start()
    {
        toggle.GetComponent<Toggle>().isOn = SendInfo.audioToggleState;
    }

}
