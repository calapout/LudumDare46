using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Cadran : MonoBehaviour
{
    [SerializeField]
    private int _id;
    public int id { get { return _id; } set { _id = id; } }
    private int currentStatus { get; set; } = -1;
    private bool needSun { get; set; } = false;
    private bool isSunOver { get; set; } = false;
    private bool didThrowUnhappy = false;

    public actualizeCadran actualizeCadranEvent;

    public Timer gameOverTimer;
    public Timer timerSunLeftToReceive;
    private float unhappyTime;

    private void Start ()
    {
        GameManager.Instance.RegisterCadran ( id, this );
        actualizeCadranEvent = new actualizeCadran();
    }

    private void Update ()
    {

        if (gameOverTimer.GetTimeLeft() <= unhappyTime && !didThrowUnhappy ) {
            didThrowUnhappy = true;
            currentStatus = 1;
            actualizeCadranEvent.Invoke ( id, currentStatus, isSunOver );
        }
    }

    private void OnTriggerEnter2D(Collider2D sun) {
        if ( sun.tag == "sun" ){
            gameOverTimer.Pause();
            isSunOver = true;
            actualizeCadranEvent.Invoke ( id, currentStatus, isSunOver );
            timerSunLeftToReceive.Resume ( );
        }
    }

    private void OnTriggerExit2D(Collider2D sun) {

        if ( sun.tag == "sun" ){
            isSunOver = false;
            actualizeCadranEvent.Invoke ( id, currentStatus, isSunOver );
            timerSunLeftToReceive.Pause ();
            if ( needSun ){
                gameOverTimer.Resume ();
            }
        }
    }

    public void NeedSun ()
    {
        didThrowUnhappy = false;
        needSun = true;
        currentStatus = 2;
        actualizeCadranEvent.Invoke ( id, currentStatus, isSunOver );
        gameOverTimer.SetNewTime(GameManager.Instance.initialDelay);
        gameOverTimer.Resume();
        unhappyTime = ( GameManager.Instance.initialDelay * 0.40f > 4f ) ? GameManager.Instance.initialDelay * 0.40f : 4f;
        timerSunLeftToReceive.SetNewTime ( 3 );
    }

    public void EnoughSun ()
    {
        needSun = false;
        currentStatus = 1;
        actualizeCadranEvent.Invoke (id, currentStatus, isSunOver);
        gameOverTimer.Pause();
        GameManager.Instance.NewCadran ();
    }
}

/************************************* Events **************************************/

/// <summary>
/// t1: cadran
/// t2: status (-1 = nothing, 0 = happy, 1=unhappy, 2=needSun)
/// t3: isSunThere
/// </summary>
[System.Serializable]
public class actualizeCadran : UnityEvent<int, int, bool>{}

/// <summary>
/// change the internStatus
/// </summary>
[System.Serializable]
public class changeStatus : UnityEvent<int> { }