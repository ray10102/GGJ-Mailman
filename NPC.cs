using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	private bool waved;
	private Animator anim;

	// Use this for initialization
	void Start () {
		this.waved = false;	
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WaveBack() {
		
		this.waved = true;
		anim.SetBool ("isWaving", true);
	}

	public void EndWave() {
		anim.SetBool ("isWaving", false);
	}

	public bool GetWaved() {
		return this.waved;
	}
	public void OnTriggerEnter2D(Collider2D col)
	{

	}
	public void OnTriggerExit2D(Collider2D col)
	{





	}
}
