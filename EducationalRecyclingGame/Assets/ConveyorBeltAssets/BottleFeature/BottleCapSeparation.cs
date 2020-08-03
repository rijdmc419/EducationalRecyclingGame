using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this should be attached to ED_TestItem to manage the bottlecap separation feature
public class BottleCapSeparation : MonoBehaviour
{
    //potentialBottles loads all of the sprites from the Items image. bottleIndices tells you the indices in potentialBottles that are actually bottle sprites.
    private Sprite[] potentialBottles;
    private int[] bottleIndices = { 0, 1, 2, 8, 10 };

    //Bottle sprites and cap sprites.
    private Sprite[] allCaps;
    private Sprite[] allBottles;

    //Make a list of class instances. This class stores the whole sprite, bottle sprite, and cap sprite separately so they are easily accessed together.
    private List <BottleSpriteAssociation> bottles = new List<BottleSpriteAssociation>();

    void Awake()
    {
        potentialBottles = Resources.LoadAll<Sprite>("Sprites/Items");
        allCaps = Resources.LoadAll<Sprite>("Sprites/CapSprites");
        allBottles = Resources.LoadAll<Sprite>("Sprites/BottleSprites");

        Debug.Log("There are " + allCaps.Length + " caps");
        Debug.Log("There are " + allBottles.Length + " bottles");
        Debug.Log("There are " + bottleIndices.Length + " indices");

        /*for(int ii = 0; ii < bottleIndices.Length; ii ++)
        {
            bottles.Add(new BottleSpriteAssociation(potentialBottles[ii], allBottles[ii], allCaps[ii]));
        }*/
    }

    void OnMouseOver()
    {
        //if we are OVER the sprite and it is right clicked (AND it's a bottle sprite)
        if (Input.GetMouseButtonDown(1))
        {
            //index in bottleIndices that contains the index of the sprite in potentialBottles
            int index = SpriteIsABottle(transform.GetComponent<SpriteRenderer>().sprite);
            if (index >= 0)
            {
                //generate new sprites: bottle and cap
                //add points

                Transform bottle = Instantiate(transform);
                //set bottle sprite. (Set image + tag to recycling)****
                Debug.Log("It's a bottle. The index is " + index);
                bottle.GetComponent<SpriteRenderer>().sprite = allBottles[index];

                Transform cap = Instantiate(transform);
                //set up cap sprite. (Set image + tag to trash)****
                cap.GetComponent<SpriteRenderer>().sprite = allCaps[index];

                //delete old sprite
                Destroy(gameObject);
            }
            
        }
    }

    //determines if the sprite inputted is a bottle or not by matching it to images on the sprite sheet that are bottles.
    //Note that this assumes that all of the bottles are on the Items images and that all indices are entered in bottleIndices.
    //If it returns a positive integer, the sprite is a bottle. If it returns -1, the sprite is not a bottle.
    int SpriteIsABottle(Sprite sprite)
    {
        for(int ii = 0; ii < bottleIndices.Length; ii++)
        {
            if(sprite == potentialBottles[bottleIndices[ii]])
            {
                return ii;
            }
        }

        return -1;
    }
}

