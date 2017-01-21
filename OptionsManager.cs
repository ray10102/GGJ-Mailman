using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Slider MasterVolumeSlider;
	public Slider SFXSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;


	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		MasterVolumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		SFXSlider.value = PlayerPrefsManager.GetSFXVolume ();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (MasterVolumeSlider.value);
	}

	public void SaveAndExit () {
		PlayerPrefsManager.SetMasterVolume (MasterVolumeSlider.value);
		PlayerPrefsManager.SetSFXVolume (SFXSlider.value);
		levelManager.LoadLevel ("01a Start Menu");
	}

	public void SetDefaults () {
		MasterVolumeSlider.value = .5f;
		SFXSlider.value = 2f;
	}
}
