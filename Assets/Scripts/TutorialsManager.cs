using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialsManager : MonoBehaviour
{
    public Animator animSunChan;
    public Animator animSun;
    public Animator animMoonChan;
    public Animator animMoon;

    public void PlaySunChanAnim()
    {
        animSunChan.Play("SunChanTutorial", -1, 0);
        animSun.Play("SunExclamation", -1, 0);
    }
    public void PlayMoonChanAnim()
    {
        animMoonChan.Play("MoonChanTutorial", -1, 0);
        animMoon.Play("MoonExclamation", -1, 0);
    }

}
