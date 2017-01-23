using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_SFXManager : MonoBehaviour {

    public AudioClip[] background_sfxs;
    public int min_frames_between_sound; //This is the minimum frames required between sound effects
    public int one_out_of_a;//This is the value that represents the "out of" in 1 out of a number. So 1 out of 5 would give you 20% chances of the event happenning in a given frame


    private AudioSource[] audioSource;
    private int frames_since_last_sfx = 0;//frames since last sfx played. Initialized to 0

    private int rand_num;//variable to store a random int

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = new AudioSource[background_sfxs.Length];
        /* for loop to creates audio sources for each sfx*/
        for (int ii = 0; ii < background_sfxs.Length; ii = ii + 1)
        {
            audioSource[ii] = gameObject.AddComponent<AudioSource>();
            audioSource[ii].clip = background_sfxs[ii];
            audioSource[ii].loop = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

		Debug.Log (min_frames_between_sound);

        //Okay let's make some sounds... randomly

        //If the frames from last sfx is greater than the minimum required frames between sound effects
        //then randomly decide to make a sound effect
        if (frames_since_last_sfx > min_frames_between_sound)
        {
            rand_num = Random.Range(0, one_out_of_a);

            if (rand_num == 1)
            {
				int rand_num = Random.Range(0, audioSource.Length-1);
				//Update the volume
				audioSource[rand_num].volume = PlayerPrefsManager.GetSFXVolume();
				audioSource[rand_num].Play();//Play the sound
                frames_since_last_sfx = 0; //reset the frame count
            }
                   
        }
        frames_since_last_sfx = frames_since_last_sfx + 1;

    }
}
