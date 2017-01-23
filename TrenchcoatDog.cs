using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchcoatDog : MonoBehaviour {
	private Animator anim;


	public GameObject player;
    public GameObject[] runningDogs;

	private Vector3 PlayerPos;
	private Vector3 DogPos;
	private bool DogChasingLeft;
	private bool playerInRange;
	private SFXManager sfx;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		player = FindObjectOfType<PlayerController> ().gameObject;
		sfx = FindObjectOfType<SFXManager>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerInRange) {
			PlayerPos = player.transform.position;
			DogPos = this.transform.position;

			DogChasingLeft = (PlayerPos.x < DogPos.x);

			Debug.Log(DogChasingLeft );

			if (Input.GetKeyUp (KeyCode.Space)) {

				sfx.make_sfx ("dog barking1");
				if (DogChasingLeft) {
					//anim.SetBool ("DogStay", false);
					anim.SetTrigger ("Drun1");
					trenchcoatSound ();
					//anim.SetBool("ChasingRight", fa);
					//chasing left
					Debug.Log("2 "  );
				} else {
					//anim.SetBool ("DogStay", false);
					anim.SetTrigger ("Drun2");
					trenchcoatSound ();
					//anim.SetTrigger ("ChasingRight", true);
					//chasing right
				} 
			} 

		} 
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		GameObject obj = col.gameObject;

		if (obj.GetComponent<PlayerController>())
		{
			playerInRange = true;
            anim.SetBool("playerInRange", true);


		}

	}



	void OnTriggerExit2D(Collider2D col)
	{


		playerInRange = false;
        anim.SetBool("playerInRange", false);


	}
	public void spawnDog (int n) {
        Instantiate(runningDogs[n], this.transform.position, Quaternion.identity);
	} 

	public void trenchcoatSound ()
	{
		sfx.make_sfx ("trenchcoat");
	}
}
