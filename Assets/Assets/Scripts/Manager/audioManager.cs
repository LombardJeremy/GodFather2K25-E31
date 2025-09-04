using UnityEngine;
using System;

public class audioManager : MonoBehaviour
{
    public static audioManager Instance;

    public AudioClip[] MusicSounds, sfxSounds;
    public AudioSource MusicSource, sfxSource;

    private void Awake()
    {
        if (Instance = null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        AudioClip s = Array.Find(MusicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sounds not found");
        }
        else
        {
            MusicSource.clip = s;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        AudioClip s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sounds not found");
        }

        else
        {
            sfxSource.PlayOneShot(s);
        }
    }
}
