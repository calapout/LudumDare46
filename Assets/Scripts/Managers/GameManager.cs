using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Dictionary<int, Cadran> cadranList { get; } = new Dictionary<int, Cadran> ( );
    private List<int> indexPool = new List<int>();
    private int indexReference = -1;
    public float initialDelay = 15;
    public Timer gameTimer;

    // Start is called before the first frame update
    void Start ()
    {
        Instance.gameTimer.Resume();
        Instance.NewCadran ();
    }

    // Update is called once per frame
    void Update()
    {
    }

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

    public void Gameover ()
    {
        SceneManager.LoadScene("gameOver");
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
        yield return new WaitForSecondsRealtime (3);
        Instance.ChooseNextCadran ();
    }
}
