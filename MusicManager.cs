using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public AudioClip StartMenuMusic;

    static AudioSource audioSource = null;

    void Awake()
    {
		//if (instance != null) {
		//	instance.StopMusic ();
		//	DestroyObject(gameObject);
		//}
		//else{
		//	instance = this;
			DontDestroyOnLoad(gameObject);
		//}
    }

    void Start()
    {
		Debug.Log (audioSource);
		if (audioSource == null) {
			audioSource = gameObject.AddComponent<AudioSource> ();
			audioSource.clip = StartMenuMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
      
    }

	// Update is called once per frame
	void Update () {

		//musicManager.ChangeVolume (MusicVolumeSlider.value);
		//musicManager.ChangeVolume (SFXSlider.value);
		audioSource.volume  = PlayerPrefsManager.GetMusicVolume();
		//PlayerPrefsManager.SetSFXVolume (SFXSlider.value);
	}

	// Update is called once per frame
	public void StopMusic () {
		//musicManager.ChangeVolume (MusicVolumeSlider.value);
		//musicManager.ChangeVolume (SFXSlider.value);
		audioSource.Stop();		//PlayerPrefsManager.SetSFXVolume (SFXSlider.value);
	}



 
}