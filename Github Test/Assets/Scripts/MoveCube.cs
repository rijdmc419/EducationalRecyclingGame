using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, 0.1f, 0f);
    }
}
