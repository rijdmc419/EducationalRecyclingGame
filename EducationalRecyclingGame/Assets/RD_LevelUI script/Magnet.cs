using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // Start is called before the first frame update


    void Update() {

        if (Input.GetKeyDown("m") && this.GetComponent<BoostsScript>().AmountPressed() < 3
            && SendInfo.gamePlay) {
        	Debug.Log("m pressed");
            OnButtonPress();
        }
    }


    public void OnButtonPress() {


    	StartCoroutine(Time());
    	this.GetComponent<BoostsScript>().CheckLimit();


    }


    IEnumerator Time() {

    	this.transform.GetChild(1).gameObject.SetActive(true);

        // waits 4 seconds
        yield return new WaitForSeconds(4);

        this.transform.GetChild(1).gameObject.SetActive(false);
    

    }


}
