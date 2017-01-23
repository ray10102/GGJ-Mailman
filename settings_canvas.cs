using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings_canvas : MonoBehaviour {


	void Awake(){
		gameObject.transform.FindChild ("General Options Panel").gameObject.GetComponent<GeneralOptionsManager>().Activate ();
		gameObject.transform.FindChild ("Subtitle option gui").gameObject.GetComponent<SubtitleOptionsManager>().Deactivate ();

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);

	}

	public void Activate()
	{
		gameObject.SetActive(true);
		gameObject.transform.FindChild ("General Options Panel").gameObject.GetComponent<GeneralOptionsManager>().Activate ();
		gameObject.transform.FindChild ("Subtitle option gui").gameObject.GetComponent<SubtitleOptionsManager>().Deactivate ();

	}
}
