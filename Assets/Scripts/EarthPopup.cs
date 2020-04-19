using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class EarthPopup : EarthThing
{
    SpriteRenderer sp;
    Animator animator;
    public void Show(Sprite sprite)
    {
        if (sp == null) { sp = this.transform.GetChild(0).GetComponent<SpriteRenderer>(); }

        sp.sprite = sprite;
        Show();

        if (animator == null) { animator = this.transform.GetComponent<Animator>(); }
        Utils.PlayAnimatorClip(animator, "Popup_Appear", null);
    }
    public void Hide(bool playAnim)
    {
        if (playAnim == false) { base.Hide(); }
        else
        {
            if (animator == null) { animator = this.transform.GetComponent<Animator>(); }
            Utils.PlayAnimatorClip(animator, "Popup_Disappear", () => { base.Hide(); });
        }
    }
}
