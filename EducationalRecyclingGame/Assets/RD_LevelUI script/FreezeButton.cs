using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeButton : MonoBehaviour
{
    public float slowdownfactor;
    public float slowdowntime;
    public GameObject player;

    public void Start()
    {
        if (player.activeSelf == false)
        {
            StartCoroutine(WaitThenRestoreTime());
        }
    }
    
    private IEnumerator WaitThenRestoreTime()
    {
        Time.timeScale = slowdownfactor;
        yield return new WaitForSecondsRealtime(slowdowntime);
        Time.timeScale = 1f;
    }
}