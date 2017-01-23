using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneralOptionsManager : MonoBehaviour {

	public Slider MusicVolumeSlider;
	public Slider SFXSlider;
	public AudioClip sfx_slider_click;

	private AudioSource audioSource;

	public LevelManager levelManager;
	private float sfx_slider_delta;
	private float last_sfx_value;

	//private MusicManager musicManager;


	// Use this for initialization
	void Start () {
	//	musicManager = GameObject.FindObjectOfType<MusicManager> ();
		MusicVolumeSlider.value = PlayerPrefsManager.GetMusicVolume();
		SFXSlider.value = PlayerPrefsManager.GetSFXVolume();
		last_sfx_value = SFXSlider.value;
		sfx_slider_delta = 0f;

		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = sfx_slider_click;
		audioSource.loop = false;;

	}
	
	// Update is called once per frame
	void Update () {
		//musicManager.ChangeVolume (MusicVolumeSlider.value);
		//musicManager.ChangeVolume (SFXSlider.value);
		//Calculate the change
		sfx_slider_delta = sfx_slider_delta + last_sfx_value - SFXSlider.value;
		//store the sfx value for next frame
		last_sfx_value = SFXSlider.value;

		//Aim to play a click every tenth portion of the slider bar
		if (Mathf.Abs(sfx_slider_delta) >= 0.1f)
		{	
			audioSource.volume = SFXSlider.value;
			audioSource.Play ();//play a click!!!

			sfx_slider_delta = 0;//reset counter

		}	

		PlayerPrefsManager.SetMusicVolume (MusicVolumeSlider.value);
		PlayerPrefsManager.SetSFXVolume (SFXSlider.value);
	}

	public void SaveAndExit () {

		//levelManager.LoadLevel ("01a Start Menu");
		gameObject.SetActive (false);

	}

	public void SetDefaults () {
		MusicVolumeSlider.value = .5f;
		SFXSlider.value =.5f;
	}


	public void Deactivate()
	{
		gameObject.SetActive(false);

	}

	public void Activate()
	{
		gameObject.SetActive(true);

	}

}
