using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioClip[] greetings,dogs,mailbox,footsteps,alert;

	public AudioClip truck;

	private AudioSource[] greetingsAudioSource,dogsAudioSource,mailboxAudioSource,footstepsAudioSource,alertsAudioSource;
	private AudioSource truckAudioSource;

	private string[] greetingsText = {"Hello!!!","Howdy!!","How Ya Doing??", "Sup","Bonjour!!!!","Hola","Ciao","Guten Tag","Sallam"};

	private string[] dogsText = { "Woof Woof!", "Bow Wow", "Grrrrrr", "Bark Bark!!!", "Ruff.... Ruff", "Yawp!", "Meow?!?!?" };
	private string[] mailboxText = { "Clank", "Jangle", "Rattle!" };
	private string[] footstepsText = { "<FootSteps>" };
	private string[] alertText = { "eeeoooeeeoo" };
	private string trucktText =  "Vrooooom!";

	private SubtitleManager subtitleObject;
    private int frames_since_last_sfx = 0;//frames since last sfx played. Initialized to 0

    private int rand_num;//variable to store a random int

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
		

		subtitleObject = gameObject.transform.parent.gameObject.GetComponent<SubtitleManager> ();

		//Do audio

		//truck
		truckAudioSource = gameObject.AddComponent<AudioSource>();
		truckAudioSource.clip = truck;
		truckAudioSource.loop = false;

		//Greetings
		greetingsAudioSource = new AudioSource[greetings.Length];
        /* for loop to creates audio sources for each sfx*/
		for (int ii = 0; ii < greetings.Length; ii = ii + 1)
        {
			greetingsAudioSource[ii] = gameObject.AddComponent<AudioSource>();
			greetingsAudioSource[ii].clip = greetings[ii];
			greetingsAudioSource[ii].loop = false;
        }

		//dog
		dogsAudioSource = new AudioSource[dogs.Length];
		/* for loop to creates audio sources for each sfx*/
		for (int ii = 0; ii < dogs.Length; ii = ii + 1)
		{
			dogsAudioSource[ii] = gameObject.AddComponent<AudioSource>();
			dogsAudioSource[ii].clip = dogs[ii];
			dogsAudioSource[ii].loop = false;
		}

		//Mailbox
		mailboxAudioSource = new AudioSource[mailbox.Length];
		/* for loop to creates audio sources for each sfx*/
		for (int ii = 0; ii < mailbox.Length; ii = ii + 1)
		{
			mailboxAudioSource[ii] = gameObject.AddComponent<AudioSource>();
			mailboxAudioSource[ii].clip = mailbox[ii];
			mailboxAudioSource[ii].loop = false;
		}

		//footsteps
		footstepsAudioSource = new AudioSource[footsteps.Length];
		/* for loop to creates audio sources for each sfx*/
		for (int ii = 0; ii < footsteps.Length; ii = ii + 1)
		{
			footstepsAudioSource[ii] = gameObject.AddComponent<AudioSource>();
			footstepsAudioSource[ii].clip = footsteps[ii];
			footstepsAudioSource[ii].loop = false;
		}

		//footsteps
		alertsAudioSource = new AudioSource[alert.Length];
		/* for loop to creates audio sources for each sfx*/
		for (int ii = 0; ii < alert.Length; ii = ii + 1)
		{
			alertsAudioSource[ii] = gameObject.AddComponent<AudioSource>();
			alertsAudioSource[ii].clip = alert[ii];
			alertsAudioSource[ii].loop = false;
			//Extra code to reverse the waveform
			alertsAudioSource [ii].timeSamples = alertsAudioSource [ii].clip.samples - 1;
			alertsAudioSource [ii].pitch = -1;
		}




    }

    // Update is called once per frame
    void Update()
    {

		 
        //Okay let's make some sounds... randomly

        //If the frames from last sfx is greater than the minimum required frames between sound effects
        //then randomly decide to make a sound effect
       // if (frames_since_last_sfx > min_frames_between_sound)
       // {
         //   rand_num = Random.Range(0, one_out_of_a);
          //  if (rand_num == 1)
           // {
			//	int rand_num = Random.Range(0, audioSource.Length-1);
				//Update the volume
			//	audioSource[rand_num].volume = PlayerPrefsManager.GetSFXVolume();
			//	audioSource[rand_num].Play();//Play the sound
              //  frames_since_last_sfx = 0; //reset the frame count
            //}
                   
        //}
        //frames_since_last_sfx = frames_since_last_sfx + 1;

    }

	public void make_sfx(string soundtype)
	{
		int rand_num;


		switch (soundtype){

		case "greeting":
			rand_num = Random.Range(0, greetingsAudioSource.Length-1);
			//Update the volume
			greetingsAudioSource[rand_num].volume = PlayerPrefsManager.GetSFXVolume();
			greetingsAudioSource[rand_num].Play();//Play the sound
			break;
		case "dog":
			rand_num = Random.Range (0, dogsAudioSource.Length - 1);
			Debug.Log (rand_num);
			//Update the volume
			dogsAudioSource[rand_num].volume = PlayerPrefsManager.GetSFXVolume();
			dogsAudioSource[rand_num].Play();//Play the sound
			break;
		case "alert":
			rand_num = Random.Range(0, alertsAudioSource.Length-1);
			//Update the volume
			alertsAudioSource[rand_num].volume = PlayerPrefsManager.GetSFXVolume();
			alertsAudioSource[rand_num].Play();//Play the sound
			break;
		case "mailbox":
			rand_num = Random.Range(0, mailboxAudioSource.Length-1);
			//Update the volume

			mailboxAudioSource[rand_num].volume = PlayerPrefsManager.GetSFXVolume();
			mailboxAudioSource[rand_num].Play();//Play the sound
			break;
		case "footstep":
			rand_num = Random.Range(0, footstepsAudioSource.Length-1);
			//Update the volume
			footstepsAudioSource[rand_num].volume = PlayerPrefsManager.GetSFXVolume();
			footstepsAudioSource[rand_num].Play();//Play the sound
			break;
		case "truck":
			truckAudioSource.volume = PlayerPrefsManager.GetSFXVolume ();
			truckAudioSource.Play ();
			break;
		default:
			Debug.Log("What the hell is a"  + soundtype + "?");
			break;

		}

	
	}

	public void make_sfx(string soundtype,string prefix)
	{

		string soundText;
		int rand_num;
		bool Run = true;
		switch (soundtype){

		case "greeting":
			rand_num = Random.Range (0, greetingsText.Length - 1);
			soundText = greetingsText [rand_num];
			break;
		case "dog":
			rand_num = Random.Range(0, dogsText.Length-1);
			soundText = dogsText [rand_num];

			break;
		case "alert":
			rand_num = Random.Range(0, alertText.Length-1);
			soundText = alertText [rand_num];

			break;
		case "mailbox":
			rand_num = Random.Range(0, mailboxText.Length-1);
			soundText = mailboxText [rand_num];

			break;
		case "footstep":
			rand_num = Random.Range(0, footstepsText.Length-1);
			soundText = footstepsText [rand_num];

			break;
		case "truck":

			soundText = trucktText;

			break;
		default:
			Debug.Log ("What the hell is a" + soundtype + "?");
			Run = false;
			soundText = "";
			break;

		}

		if (Run) {

			subtitleObject.broadcast_subtitle(prefix + " " + soundText);
			this.make_sfx (soundtype);

		}
	}


	public void make_announcement(string text,int numFrames)
	{


		subtitleObject.broadcast_subtitle(text,numFrames);

	}


}

