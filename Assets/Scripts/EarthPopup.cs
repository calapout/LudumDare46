using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPopup : EarthThing
{
    SpriteRenderer sp;
    public void Show(Sprite sprite)
    {
        if (sp == null) { sp = this.transform.GetChild(0).GetComponent<SpriteRenderer>(); }

        sp.sprite = sprite;
        Show();
    }
}
