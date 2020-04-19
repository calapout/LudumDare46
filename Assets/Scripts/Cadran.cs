using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Cadran : MonoBehaviour
{
    [SerializeField]
    private int _id;
    public int id { get { return _id; } set { _id = id; } }
    private bool isNeedingSun { get; set; } = false;
    private bool isSunOver { get; set; } = false;
    private bool didThrowUnhappy = false;

    public actualizeCadran actualizeCadranEvent;

    public Timer gameOverTimer;
    public Timer timerSunLeftToReceive;
    private float unhappyTime;

    private void Start ()
    {
        GameManager.Instance.RegisterCadran ( id, this );
    }

    private void Update ()
    {
        if ( !isNeedingSun ) {
            return;
        }

        if (gameOverTimer.GetTimeLeft() <= unhappyTime && !didThrowUnhappy ) {
            didThrowUnhappy = true;
            ThrowEvent ( 1, isSunOver );
        }
    }

    private void OnTriggerEnter2D(Collider2D sun) {
        if ( sun.tag == "sun"  ){
            isSunOver = true;
            ThrowEvent (-2, isSunOver);

            if ( !isNeedingSun ) return;

            gameOverTimer.Pause();
            timerSunLeftToReceive.Resume ( );
        }
    }

    private void OnTriggerExit2D(Collider2D sun) {

        if ( sun.tag == "sun" ){
            isSunOver = false;
            ThrowEvent (-2, isSunOver);

            if ( !isNeedingSun ) return;

            timerSunLeftToReceive.Pause ();
            gameOverTimer.Resume ();
        }
    }

    public void NeedSun ()
    {
        didThrowUnhappy = false;
        isNeedingSun = true;
        ThrowEvent (2, isSunOver);
        gameOverTimer.SetNewTime(GameManager.Instance.initialDelay);
        gameOverTimer.Resume();
        unhappyTime = ( GameManager.Instance.initialDelay * 0.40f > 4f ) ? GameManager.Instance.initialDelay * 0.40f : 4f;
        timerSunLeftToReceive.SetNewTime ( 3 );
    }

    public void EnoughSun ()
    {
        isNeedingSun = false;
        ThrowEvent (0, isSunOver);
        gameOverTimer.Pause ();
        timerSunLeftToReceive.Pause ();
        GameManager.Instance.NewCadran ();
    }

    public void ThrowEvent (int currentStatus, bool isSunOver)
    {
        actualizeCadranEvent.Invoke (id, currentStatus, isSunOver);
    }
}

/************************************* Events **************************************/

/// <summary>
/// t1: cadran
/// t2: status (-2 = nothing, -1 = closeBubble, 0 = happy, 1=unhappy, 2=needSun)
/// t3: isSunThere
/// </summary>
[System.Serializable]
public class actualizeCadran : UnityEvent<int, int, bool>{}

/// <summary>
/// change the internStatus
/// </summary>
[System.Serializable]
public class changeStatus : UnityEvent<int> { }