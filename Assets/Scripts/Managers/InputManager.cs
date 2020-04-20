using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : Singleton<InputManager>
{
    public GameObject sun;
    public GameObject moon;
    delegate void Move (float direction);

    private Dictionary<string, Move> functionByAxis { get; set; } = new Dictionary<string, Move> ();

    private void Awake ()
    {
        Instance.EnableSun ();
    }


    // Update is called once per frame
    void Update()
    {
        RotatePlanets ();
    }

    private void FixedUpdate ()
    {
        foreach ( KeyValuePair<string, Move> keypair in Instance.functionByAxis )
        {
            keypair.Value (Input.GetAxisRaw (keypair.Key));
        }
    }

    public void EnableMoon ()
    {
        Instance.addAxisToMove ("moon", MoveMoon);
    }

    public void EnableSun ()
    {
        Instance.addAxisToMove("sun", MoveSun);
    }

    private void addAxisToMove (string inputName, Move functionName) {
        Instance.functionByAxis.Add (inputName, functionName);
    }

    private void MoveSun (float direction) {
        sun.transform.Rotate (new Vector3 (0, 0, direction));
    }

    private void MoveMoon (float direction)
    {
        moon.transform.Rotate (new Vector3 (0, 0, direction * 1.05f));
    }

    private void RotatePlanets ()
    {
        sun.transform.Rotate (new Vector3 (0, 0, -Time.deltaTime));
        moon.transform.Rotate (new Vector3 (0, 0, -Time.deltaTime));
    }
}
