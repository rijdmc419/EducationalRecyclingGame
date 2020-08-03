using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this should be attached to ED_TestItem to manage the bottlecap separation feature
public class BottleCapSeparation : MonoBehaviour
{
    //potentialBottles loads all of the sprites from the Items image. bottleIndices tells you the indices in potentialBottles that are actually bottle sprites.
    private Sprite[] potentialBottles;
    private int[] bottleIndices = { 0, 1, 2 };

    //Bottle sprites and cap sprites. Sprites need to be in the same order as the bottleIndices.
    private Sprite[] allCaps;
    private Sprite[] allBottles;

    private RD_Level_Script CanvasScript;

    int index;

    void Awake()
    {
        potentialBottles = Resources.LoadAll<Sprite>("Sprites/Items");
        allCaps = Resources.LoadAll<Sprite>("Sprites/CapSprites");
        allBottles = Resources.LoadAll<Sprite>("Sprites/BottleSprites");

        CanvasScript = GameObject.Find("Canvas").GetComponent<RD_Level_Script>();
    }

    void Start()
    {
        //check if the sprite is a bottle
        index = SpriteIsABottle(transform.GetComponent<SpriteRenderer>().sprite);
        //if so, reassign the tag
        if (index >= 0)
        {
            Debug.Log("Multiple");
            gameObject.tag = Constants.TAG_MULTIPLE;
        }
    }
    void OnMouseOver()
    {
        //if we are OVER the sprite and it is right clicked {AND it's a bottle sprite}
        if (Input.GetMouseButtonDown(1))
        {
            //index in bottleIndices that contains the index of the sprite in potentialBottles
            

            if (index >= 0)
            {
                //generate new sprites: bottle and cap

                Transform bottle = Instantiate(transform);
                //set bottle sprite. (Set image + tag to whatever this tag is)****
                bottle.GetComponent<ItemManager>().setUpSpecificItem(allBottles[index], Constants.TAG_PLASTIC);

                Transform cap = Instantiate(transform);
                //set up cap sprite. (Set image + tag to trash)****
                cap.GetComponent<ItemManager>().setUpSpecificItem(allCaps[index], Constants.TAG_TRASH);
                cap.GetComponent<SpriteRenderer>().size = new Vector2(0.2f, 0.15f);
                //add 10 points
                CanvasScript.GainPoints(10);

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

