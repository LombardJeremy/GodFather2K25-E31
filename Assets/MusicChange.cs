using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicChange : MonoBehaviour
{
    private AudioSource AudioSource;

    public AudioResource[] musicResources;
    private bool IsPlayingMain;
    private bool IsPlayingMinigame;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        IsPlayingMain = false;
        IsPlayingMinigame = false;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!IsPlayingMain)
            {
                IsPlayingMain = true;
                IsPlayingMinigame = false;
                AudioSource.resource = musicResources[0];
                AudioSource.Play();
            }

        }
        else
        {
            if (!IsPlayingMinigame)
            {
                IsPlayingMinigame = true;
                IsPlayingMain = false;
                AudioSource.resource = musicResources[1];
                AudioSource.Play();
            }
        }
}
}