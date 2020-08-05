using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeButton : MonoBehaviour
{
    public float slowdownfactor;
    public float slowdowntime;

    public void Freeze ()
    {
        StartCoroutine(WaitThenRestoreTime());

    }

    private IEnumerator WaitThenRestoreTime()
    {
        Time.timeScale = slowdownfactor;
        yield return new WaitForSecondsRealtime(slowdowntime);
        Time.timeScale = 1f;
    }

}