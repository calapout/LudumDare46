using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public AudioSource soundSource;
    public Slider sliderSound;
    public AudioSource musicSource;
    public Slider sliderMusic;
    private void Awake()
    {
        sliderSound.onValueChanged.AddListener((v)=> {
            musicSource.volume = v / 13f;
        });
        sliderMusic.onValueChanged.AddListener((v) => {
            SoundManager.soundVolume = v / 10f;
        });
    }
}
