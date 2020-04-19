using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[System.Serializable]
public class SoundWithVolume
{
    public AudioClip clip;
    public float volume;
}

public class SoundManager : MonoBehaviour
{
    static public float soundVolume = 1f;
    static private SoundManager instance;
    public SoundWithVolume[] sounds;
    private void Awake()
    {
        instance = this;
    }

    static public void PlaySound(int index)
    {
        instance.GetComponent<AudioSource>().PlayOneShot(instance.sounds[index].clip, instance.sounds[index].volume * soundVolume);
    }
    public void PlaySoundPublic(int index)
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[index].clip, sounds[index].volume * soundVolume);
    }
}
