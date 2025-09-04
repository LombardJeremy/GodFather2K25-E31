using UnityEngine;
using System;

public class audioManager : MonoBehaviour
{
    public static audioManager Instance;

    public Sound[] MusicSounds, sfxSounds;
    public AudioSource MusicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(MusicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sounds not found");
        }
        else
        {
            MusicSource.clip = s.sound;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sounds not found");
        }

        else
        {
            sfxSource.PlayOneShot(s.sound);
        }
    }

    public void MusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }
    public void sfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }   
}
