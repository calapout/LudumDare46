using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public EarthPopup[] earthPopups;
    public EarthZone[] earthZones;
    public Sprite[] stateSprites;
    private void Awake()
    {
        CloseAll();
        //SetState(1, 1, true);

        //StartCoroutine(wait());
    }
    private void CloseAll() {
        foreach (EarthPopup p in earthPopups)
        {
            p.Hide(false);
        }
        foreach (EarthZone z in earthZones)
        {
            z.Hide();
        }
    }
    public void SetState(int zoneNumber, int state, bool hasLight)
    {
        if (state == -1)
        {
            earthPopups[zoneNumber].Hide(true);
            earthZones[zoneNumber].Hide();
        }
        else
        {
            earthPopups[zoneNumber].Show(stateSprites[state]);
            earthZones[zoneNumber].Show(hasLight);
        }
    }

    /*IEnumerator wait() {
        yield return new WaitForSecondsRealtime(5f);
        SetState(1, -1, false);
        SetState(0, 2, true);
    }*/
}
