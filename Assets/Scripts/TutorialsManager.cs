using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class TutorialsManager : MonoBehaviour
{
    public Animator animSunChan;
    public Animator animSun;
    public Animator animMoonChan;
    public Animator animMoon;

    public void PlaySunChanAnim()
    {
        PauseController.canControl = false;
        Utils.PlayAnimatorClip(animSunChan, "SunChanTutorial", ()=> { PauseController.canControl = true; });
        animSun.Play("MoonExclamation", -1, 0);
    }
    public void PlayMoonChanAnim()
    {
        PauseController.canControl = false;
        Utils.PlayAnimatorClip(animMoonChan, "MoonChanTutorial", () => { PauseController.canControl = true; });
        animMoon.Play("MoonExclamation", -1, 0);
    }

}
