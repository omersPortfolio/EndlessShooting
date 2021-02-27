using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundEffects;

    void Awake()
    {
        instance = this;
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].Play();
    }

    public void PlayRifleSFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }

    
}
