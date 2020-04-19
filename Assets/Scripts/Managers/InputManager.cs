using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : Singleton<InputManager>
{
    GameObject sun;
    Rigidbody2D moonRB;
    delegate void Move (float direction);

    private Dictionary<string, Move> functionByAxis { get; set; } = new Dictionary<string, Move> ();

    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.FindGameObjectWithTag ("sun");
        //moonRB = GameObject.FindGameObjectWithTag ("moon");
        Instance.EnableSun ();
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
