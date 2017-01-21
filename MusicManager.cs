using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public AudioClip StartMenuMusic;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = StartMenuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ChangeVolume(float volume) {
        audioSource.volume = volume;
    }
}