using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{

    private GameObject earth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setEarth (GameObject target)
    {
        earth = target;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards (transform.position, earth.transform.position, Time.deltaTime * 1f);
        transform.rotation = GetCometAngle (gameObject, earth);

    }

    private Quaternion GetCometAngle (GameObject comet, GameObject target)
    {
        Vector3 targ = target.transform.position;
        targ.z = 0f;

        Vector3 objectPos = comet.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2 (targ.y, targ.x) * Mathf.Rad2Deg;
        return Quaternion.Euler (new Vector3 (0, 0, angle));
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log (collision.tag);
        if ( collision.tag == "earth" )
        {

        }

        if ( collision.tag == "earth" || collision.tag == "moon" || collision.tag == "sun" )
        {
            Destroy (gameObject);
        }

    }
}
