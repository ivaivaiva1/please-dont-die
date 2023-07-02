using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip BGM;

    public AudioSource bgmaudioSource;

    public AudioSource FXaudioSource;

    public static AudioController instance;

    private void Awake() 
    {
        if(instance != null)
        {
           Destroy(this);
           return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        bgmaudioSource.loop = true;
        bgmaudioSource.clip = BGM;
        bgmaudioSource.Play();
    }

    public void PlayFX(AudioClip clip, float volume = 1)
    {
       FXaudioSource.volume = volume;
       FXaudioSource.PlayOneShot(clip);
    }
}
