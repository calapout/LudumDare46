using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    GameObject earth;

    private void Start ()
    {
        earth = GameObject.FindGameObjectWithTag ("earth");
    }

    void Update()
    {
    }
}
