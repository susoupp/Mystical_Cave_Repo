using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource audioSource;
  

    void Awake()
    {
        audioSource.Stop();
        audioSource = GetComponent<AudioSource>();
    }

    public void Stop()
    {
        audioSource.Stop();
         
    }
    public void Play()
    {
        audioSource.Play();
         
    }

}
