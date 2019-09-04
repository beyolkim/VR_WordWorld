using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Music : MonoBehaviour
{
    public AudioClip BackgroundSfx;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BackgroundSfx;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
