using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSpace : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, 0.32f * Time.deltaTime));
    }
}
