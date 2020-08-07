using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{

    public void OnButtonPress() {

    	StartCoroutine(WaitThenRestoreTime());

    }


    private IEnumerator WaitThenRestoreTime() {
        // activates message
        this.transform.GetChild(0).gameObject.SetActive(true);

        // waits 2 seconds
        yield return new WaitForSeconds(2);
        
        // activates message
        this.transform.GetChild(0).gameObject.SetActive(false);

    }
}
