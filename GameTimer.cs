using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds;
	public bool isEndOfLevel;
	
	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject winText;
	private bool spawnersDeactivated;

	// Use this for initialization
	void Start () {
		spawnersDeactivated = false;
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		isEndOfLevel = false;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		winText = GameObject.Find ("WinText");
		if (!winText) {
			Debug.LogWarning ("No win text found");
		}
		winText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = 1 -  Time.timeSinceLevelLoad / levelSeconds;
		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			if (true) { // TODO : test condition
                isEndOfLevel = true;                
				audioSource.Play ();
				winText.SetActive (true);
				Invoke ("LoadNextLevel", audioSource.clip.length);
			}
		}
	}

	void LoadNextLevel () {
		levelManager.LoadNextLevel ();
	}
}
