using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthThing : MonoBehaviour
{
    public virtual void Show()
    {
        SpriteRenderer[] renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sp in renderers)
        {
            sp.enabled = true;
        }
    }
    public virtual void Hide()
    {
        SpriteRenderer[] renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sp in renderers)
        {
            sp.enabled = false;
        }
    }
}
