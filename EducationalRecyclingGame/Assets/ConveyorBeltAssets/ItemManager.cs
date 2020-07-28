using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    /*Eventually, we might want different arrays for different levels.
      (Or have an array/list of images instead of tags, and have tags associated with images)
      Also this probably shouldn't be in itemManager, since it is constant for all levels.
      This is just a test.*/
    private string[] arrayOfTags = { Constants.TAG_RECYCLING, 
                                    Constants.TAG_COMPOST,
                                    Constants.TAG_TRASH };

    void Awake()
    {

    }

    public void setUpRandomItem()
    {
        //place the item here
        transform.localPosition = new Vector3(3, 4, 0);

        int itemTypeInt = UnityEngine.Random.Range(0, arrayOfTags.Length);
        gameObject.tag = arrayOfTags[itemTypeInt];
    }
}
