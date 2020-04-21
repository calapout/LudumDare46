using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class Explosion : MonoBehaviour
{
    static public Explosion inst;
    private void Awake()
    {
        inst = this;
    }

    public void AnimExplosionEnd(Vector3 pos)
    {
        this.transform.parent.position = pos;
        GetComponent<Animator>().Play("Explosion", -1, 0);
        bool done = false;
        Animate.LerpSomething(4f, (f) => {
            if (done) { return; }
            Time.timeScale = 1f - f;
            if (Time.timeScale <= 0.33f) { Time.timeScale = 0; done = true; GameManager.Instance.Gameover(); }
        });
    }
    public void AnimExplosion(Vector3 pos)
    {
        this.transform.parent.position = pos;
        GetComponent<Animator>().Play("ExplosionFadeOut", -1, 0);
    }
}
