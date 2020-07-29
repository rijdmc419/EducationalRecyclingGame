using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnItems : MonoBehaviour
{
    public Transform itemPrefab;
    const double timeBtwnSpawns = 2;
    double timeLeftBeforeNextSpawn;

    // Update is called once per frame
    void Start() {
        Spawn();
    }

    void FixedUpdate()
    {
        timeLeftBeforeNextSpawn -= Time.deltaTime;

        //every so often...
        if(timeLeftBeforeNextSpawn <= 0) { Spawn(); }

    }
    
    void Spawn() {
        Transform item = Instantiate(itemPrefab);
        //access the item's script
        item.GetComponent<ItemManager>().setUpRandomItem(); 

        timeLeftBeforeNextSpawn = timeBtwnSpawns;
    }
}
