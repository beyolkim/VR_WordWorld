﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip BackgroundsSfx;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BackgroundsSfx;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
