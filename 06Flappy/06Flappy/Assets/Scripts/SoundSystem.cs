using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static SoundSystem;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;
    
    public AudioSource audioBackground;
    
    public AudioSource audioSourceCoin;
    public AudioSource audioSourceFlap;
    public AudioSource audioSourceHit;
    private void Awake()
    {
        if (SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }else if (SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoin()
    {
       audioSourceCoin.Play();
    }
    public void PlayFlap()
    {
        audioSourceFlap.Play();
    }
    public void PlayHit()
    {
        audioBackground.Stop();
        audioSourceHit.Play();
    }
    void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            instance = null;
        }
    }
}

