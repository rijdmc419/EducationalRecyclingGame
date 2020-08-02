using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this should be attached to ED_TestItem to manage the bottlecap separation feature
public class BottleCapSeparation : MonoBehaviour
{
    //list with input sprites, and list with output sprite pairs. Remember, bottleTypeInt is tracked in ItemManager.
    private int[] bottleTypeInt;
    //OR function that takes input sprite, outputs the new sprites

    void OnMouseOver()
    {
        //if we are OVER the sprite and it is right clicked (AND it's a bottle sprite---add this check later!!)****
        if (Input.GetMouseButtonDown(1))
        {
            //save position
            //generate new sprites: bottle and cap
            //add points

            Transform bottle = Instantiate(transform);
            //set bottle sprite. (Set image + tag to recycling)****

            Transform cap = Instantiate(transform);
            //set up cap sprite. (Set image + tag to trash)****

            //delete old sprite
            Destroy(gameObject);
        }
    }
}

