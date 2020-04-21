using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthZone : EarthThing
{
    public Color yellowCol;
    public Color blueCol;
    public Color redCol;
    public Color needLightCol;
    SpriteRenderer sp;
    public void Show(bool hasLight)
    {
        if (sp == null) { sp = GetComponent<SpriteRenderer>(); }

        Color newCol = (!hasLight) ? yellowCol : blueCol;
        //newCol.a = 0.5f;
        sp.color = newCol;
        Show();
    }
    public void SetNeedLight()
    {
        if (sp == null) { sp = GetComponent<SpriteRenderer>(); }

        Color newCol = needLightCol;
        //newCol.a = 0.5f;
        sp.color = newCol;
    }
    public void SetDanger()
    {
        if (sp == null) { sp = GetComponent<SpriteRenderer>(); }

        Color newCol = redCol;
        //newCol.a = 0.5f;
        sp.color = newCol;
    }
}
