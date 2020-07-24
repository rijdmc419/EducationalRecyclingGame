using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnItems : MonoBehaviour
{
    public Transform itemPrefab;
    const double timeBtwnSpawns = 1;
    double timeLeftBeforeNextSpawn;


    // Update is called once per frame
    void FixedUpdate()
    {
        timeLeftBeforeNextSpawn -= Time.deltaTime;

        //every so often...
        if(timeLeftBeforeNextSpawn <= 0)
        {
            Transform item = Instantiate(itemPrefab);
            item.localPosition = new Vector3(3, 2, 0);
            //the item could set itself up in its "Awake" function
            //OR we could set it up here. Depends.

            timeLeftBeforeNextSpawn = timeBtwnSpawns;
        }

    }
}
