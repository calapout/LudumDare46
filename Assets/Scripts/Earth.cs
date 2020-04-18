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
        SetState(1, 1, true);
    }
    private void CloseAll() {
        foreach (EarthPopup p in earthPopups)
        {
            p.Hide();
        }
        foreach (EarthZone z in earthZones)
        {
            z.Hide();
        }
    }
    public void SetState(int zoneNumber, int state, bool hasLight)
    {
        if (state == -1 || zoneNumber == -1)
        {
            CloseAll();
        }
        else
        {
            earthPopups[zoneNumber].Show(stateSprites[state]);
            earthZones[zoneNumber].Show(hasLight);
        }
    }
}
