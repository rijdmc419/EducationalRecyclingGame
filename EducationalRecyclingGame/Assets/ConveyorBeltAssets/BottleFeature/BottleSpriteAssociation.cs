using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds some sprites that are parts of a whole
public class BottleSpriteAssociation
{
    Sprite original, bottle, cap;

    public BottleSpriteAssociation(Sprite o, Sprite b, Sprite c)
    {
        original = o;
        bottle = b;
        cap = c;
    }
}