using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Dictionary<int, Cadran> cadranList { get; } = new Dictionary<int, Cadran> ( );
    private List<int> indexPool = new List<int>();
    private int indexReference = -1;
    public Timer gameTimer;
    public float initialDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer.Resume ();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RegisterCadran ( int id, Cadran cadran )
    {
        Instance.cadranList.Add ( id, cadran );
        Instance.indexPool.Add ( id );
    }

    public void ChooseNextCadran ()
    {
        int index = Random.Range ( 0, Instance.indexPool.Count );
        setNewReference ( index );
        Cadran cadran = Instance.cadranList[ index ];
        Instance.initialDelay *= 0.95f;
        cadran.NeedSun ();

    }

    private void setNewReference (int index)
    {
        if ( Instance.indexReference != -1 ) Instance.indexPool.Add ( Instance.indexReference );
        Instance.indexReference = indexPool[ index ];
        Instance.indexPool.RemoveAt ( index );
    }

    public void Gameover ()
    {

    }
}
