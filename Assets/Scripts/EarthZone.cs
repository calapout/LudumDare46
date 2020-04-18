using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthZone : EarthThing
{
    SpriteRenderer sp;
    public void Show(bool hasLight)
    {
        if (sp == null) { sp = GetComponent<SpriteRenderer>(); }

        Color newCol = (hasLight) ? Color.white : Color.yellow;
        newCol.a = 0.5f;
        sp.color = newCol;
        Show();
    }
}
