using UnityEngine;
using System;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public static audioManager Instance;

    public Sound[] MusicSounds, sfxSounds;

    [SerializeField] AudioMixer mixer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(string name, AudioSource audioSource)
    {
        Sound s = Array.Find(MusicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sounds not found");
        }
        else
        {
            audioSource.clip = s.sound;
            audioSource.Play();
        }
    }

    public void PlaySFX(string name, AudioSource audioSource)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sounds not found");
        }

        else
        {
            audioSource.PlayOneShot(s.sound);
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }
    public void ChangeSfxVolume(float volume)
    {
        mixer.SetFloat("SfxVolume", volume);
    }   

}
