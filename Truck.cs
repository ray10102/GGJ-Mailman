using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour {

	private PlayerController player;
	private Animator anim;
	private SFXManager sfx;
	// Use this for initialization
	void Start () {
		this.anim = GetComponent<Animator> ();
		player = FindObjectOfType<PlayerController> ();
		player.Deactivate ();
		sfx = FindObjectOfType<SFXManager>();
		Trucksound ();

	}
	
	// Update is called once per frame
	void Update () {
		//Trucksound ();
		
	}

	public void Idle() {
		this.player.Activate ();
	}

	public void Exit() {
		this.player.Unlock ();
		FindObjectOfType<GameTimer> ().StartTimer ();
		Renderer[] components = GetComponentsInChildren<Renderer> ();
		foreach (Renderer renderer in components) {
			renderer.enabled = false;
		}
	}


	public void Trucksound ()
	{
		sfx.make_sfx ("truck","Truck:");
		//sfx.make_announcement ("Testing", 500);
	}
}
