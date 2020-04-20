using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamation : MonoBehaviour
{

    private void OnEnable ()
    {
        StartCoroutine ("DestroySelf");
    }

    IEnumerator DestroySelf () {
        yield return new WaitForSeconds(3f);
        Destroy (gameObject);
    }
}
