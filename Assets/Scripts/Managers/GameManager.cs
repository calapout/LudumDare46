using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Bytes;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public float timeToCompleteSunZone = 0.1f;

    [SerializeField]
    public Dictionary<int, Cadran> cadranList { get; } = new Dictionary<int, Cadran> ( );
    private List<int> indexPool = new List<int>();
    private int indexReference = -1;
    public float initialDelay = 15;
    public float initialCometCooldown = 0;
    public float minCometCooldown = 0;
    public Timer gameTimer;
    public Timer cometTimer;
    public GameObject cometPrefab;
    public GameObject earth;
    public Timer moonChanTimer;
    public GameObject warningSign;

    public GameObject win;
    public GameObject lost;

    public void RegisterCadran ( int id, Cadran cadran )
    {
        Instance.cadranList.Add ( id, cadran );
        Instance.indexPool.Add ( id );
        Instance.indexPool.Sort ();
    }

    public void NewCadran()
    {
        Instance.StartCoroutine ("NewCadranIenumerator");
    }

    private void ChooseNextCadran ()
    {
        int index = Random.Range ( 0, Instance.indexPool.Count );
        if ( indexReference == -1 ) index = 3;
        setNewReference ( index );
        Cadran cadran = Instance.cadranList[Instance.indexReference];
        Instance.initialDelay *= 0.95f;
        cadran.NeedSun ();
    }

    private void setNewReference (int index)
    {
        if ( Instance.indexReference != -1 ) Instance.indexPool.Add ( Instance.indexReference );
        Instance.indexReference = Instance.indexPool[ index ];
        Instance.indexPool.RemoveAt ( index );
    }

    public void InstantiateComet ()
    {
        float radius = 3;
        Vector3 positionWarning = Instance.RandomPointOnCircleEdge (radius);
        Vector3 position = positionWarning * 3.3f;

        GameObject comet = Instantiate (cometPrefab);
        comet.transform.position = position;

        comet.GetComponent<Rigidbody2D> ().AddForce(new Vector2(-5f, 0f));
        comet.GetComponent<Comet>().setEarth (Instance.earth);
        comet.SetActive (true);

        GameObject warning = Instantiate (Instance.warningSign);

        warning.transform.position = positionWarning;
        warning.SetActive (true);

        float newTime = Mathf.Clamp (initialCometCooldown * 0.95f, Instance.minCometCooldown, initialCometCooldown);
        Instance.cometTimer.SetNewTime (newTime);
        StartCoroutine ("ResumeComet");
    }

    private Vector3 RandomPointOnCircleEdge (float radius)
    {
        float angle = Random.Range (0, 360f);

        float x = Instance.earth.transform.position.x + radius * Mathf.Cos (angle * ( Mathf.PI / 180 ));
        float y = Instance.earth.transform.position.y + radius * Mathf.Sin (angle * ( Mathf.PI / 180 ));

        return new Vector3 (x, y, 0);
    }

    public void EnableComet ()
    {
        Instance.InstantiateComet ();
        InputManager.Instance.EnableMoon ();
        StartCoroutine ("MoonChanApparition");
    }

    public void StartGame ()
    {
        Instance.gameTimer.Resume ();
        Instance.NewCadran ();
        Instance.moonChanTimer.Resume ();
    }

    public void Gameover ()
    {
        Time.timeScale = 0;
        SoundManager.ChangeMusic(1);
        lost.SetActive(true);
    }

    public void Win()
    {
        Time.timeScale = 0;
        SoundManager.ChangeMusic(2);
        win.SetActive(true);
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    IEnumerator NewCadranIenumerator ()
    {
        yield return new WaitForSecondsRealtime (3f);
        Instance.ChooseNextCadran ();
    }

    IEnumerator ResumeComet ()
    {
        yield return new WaitForSecondsRealtime (0.5f);
        Instance.cometTimer.Resume ();
    }

    IEnumerator MoonChanApparition ()
    {
        yield return new WaitForSecondsRealtime (6f);
        //GameManager.Instance.PauseGame ();
    }
}
