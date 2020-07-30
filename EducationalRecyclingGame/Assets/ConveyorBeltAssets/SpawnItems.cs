using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class SpawnItems : MonoBehaviour
{
    public Transform itemPrefab;
    const double timeBtwnSpawns = 2;
    double timeLeftBeforeNextSpawn;

    // Update is called once per frame
    void FixedUpdate()
    {
        timeLeftBeforeNextSpawn -= Time.deltaTime;

        //every so often...
        if(timeLeftBeforeNextSpawn <= 0)
        {
            Transform item = Instantiate(itemPrefab);
            //access the item's script
            item.GetComponent<ItemManager>().setUpRandomItem();
            //item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Hamburger");
            timeLeftBeforeNextSpawn = timeBtwnSpawns;
        }

    }
}
