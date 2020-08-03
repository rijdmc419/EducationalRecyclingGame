using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this should be attached to ED_TestItem to manage the bottlecap separation feature
public class BottleCapSeparation : MonoBehaviour
{
    //list with input sprites, and list with output sprite pairs. Remember, bottleTypeInt is tracked in ItemManager.
    //OR function that takes input sprite, outputs the new sprites

    //potentialBottles loads all of the sprites from the Items image. bottleIndices tells you the indices in potentialBottles that are actually bottle sprites.
    private Sprite[] potentialBottles;
    private int[] bottleIndices = { 0, 1, 2, 8, 10 };
    //array of bottle sprites + cap sprites

    void Awake()
    {
        potentialBottles = Resources.LoadAll<Sprite>("Sprites/Items");
    }

    void OnMouseOver()
    {
        //if we are OVER the sprite and it is right clicked (AND it's a bottle sprite---add this check later!!)****
        if (Input.GetMouseButtonDown(1) && SpriteIsABottle(transform.GetComponent<SpriteRenderer>().sprite))
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

    //determines if the sprite inputted is a bottle or not by matching it to images on the sprite sheet that are bottles.
    //Note that this assumes that all of the bottles are on the Items images and that all indices are entered in bottleIndices
    bool SpriteIsABottle(Sprite sprite)
    {
        for(int ii = 0; ii < bottleIndices.Length; ii++)
        {
            if(sprite == potentialBottles[bottleIndices[ii]])
            {
                Debug.Log("That's a bottle " + ii);
                return true;
            }
        }

        return false;
    }
}

