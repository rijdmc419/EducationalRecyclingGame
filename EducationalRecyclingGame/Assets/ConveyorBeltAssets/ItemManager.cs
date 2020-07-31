﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    /*Eventually, we might want different arrays for different levels.
      (Or have an array/list of images instead of tags, and have tags associated with images)
      Also this probably shouldn't be in itemManager, since it is constant for all levels.
      This is just a test.*/
    private string[] arrayOfTags = {Constants.TAG_METAL,
                                    Constants.TAG_GLASS,
                                    Constants.TAG_PAPER,
                                    Constants.TAG_PLASTIC,
                                    Constants.TAG_TRASH,
                                    Constants.TAG_COMPOST};
    private Sprite[] MostItems;
    private Sprite[] Organics;



    void Awake()
    {
        MostItems = Resources.LoadAll<Sprite>("Sprites/Items");
        Organics = new Sprite[] { Resources.Load<Sprite>("Sprites/Hamburger"),
                            Resources.Load<Sprite>("Sprites/Banana"),
                            Resources.Load<Sprite>("Sprites/Leaf"),
                            };
    }



    public void setUpRandomItem()
    {
        //place the item here
        transform.localPosition = new Vector3(3, 4, 0);
        float size = 0.4f;

        int itemTypeInt = UnityEngine.Random.Range(0, arrayOfTags.Length);
        gameObject.tag = arrayOfTags[itemTypeInt];

        //This line is to check a specific Tag as needed
        gameObject.tag = Constants.TAG_METAL;

        SpriteRenderer sprRndr = gameObject.GetComponent<SpriteRenderer>();

        sprRndr.size = new Vector2(size, size);
        if (gameObject.tag == Constants.TAG_METAL)
        {
            int ii = UnityEngine.Random.Range(12, 16);
            sprRndr.sprite = (Sprite)MostItems[ii];
            
            Debug.Log(MostItems[ii].name);
        }
        else if (gameObject.tag == Constants.TAG_GLASS)
        {
            int ii = UnityEngine.Random.Range(8, 11);
            sprRndr.sprite = (Sprite)MostItems[ii];

            Debug.Log(MostItems[ii].name);
        }
        else if (gameObject.tag == Constants.TAG_PAPER)
        {
            int ii = UnityEngine.Random.Range(5, 8);
            sprRndr.sprite = (Sprite)MostItems[ii];

            Debug.Log(MostItems[ii].name);
        }
        else if (gameObject.tag == Constants.TAG_PLASTIC)
        {
            int ii = UnityEngine.Random.Range(0, 3);
            sprRndr.sprite = (Sprite)MostItems[ii];
            
            Debug.Log(MostItems[ii].name);
        }
        else if (gameObject.tag == Constants.TAG_TRASH)
        {
            int[] randomTrash = new int[] { 3, 4, 11 };
            int ii = (randomTrash[Random.Range(0, 3)]);
            sprRndr.sprite = (Sprite)MostItems[ii];

            Debug.Log(MostItems[ii].name);
        }
        else if (gameObject.tag == Constants.TAG_COMPOST)
        {
            int ii = UnityEngine.Random.Range(0, 3);
            sprRndr.sprite = Organics[ii];

            Debug.Log(MostItems[ii].name);
        }
    }
}
