using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogs : MonoBehaviour {
	//Reference
	private Animator anim;
	private bool playerInRange;

	private bool DogChasingLeft;

	private GameObject player;
	private Vector3 PlayerPos;
	private Vector3 DogPos;
	private SFXManager sfx;
	//private var PlayerPos;
	//private var DogPos;

	private PlayerController collidedDog;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = FindObjectOfType<PlayerController> ().gameObject;
		sfx = FindObjectOfType<SFXManager>();
		//Debug.Log("Player position is: " + player.transform.position );
	}
	
	// Update is called once per frame
	void Update () {

		//print(PlayerPos);
		if (playerInRange) {
			PlayerPos = player.transform.position;
			DogPos = this.transform.position;

			DogChasingLeft = (PlayerPos.x < DogPos.x);

			Debug.Log(DogChasingLeft  );

			if (Input.GetKeyUp (KeyCode.Z)) {
				if (DogChasingLeft) {
					anim.SetTrigger ("ChasingLeft");
					sfx.make_sfx ("dog");
                    Debug.Log("2 ");
				} else {
					anim.SetTrigger ("ChasingRight");
					sfx.make_sfx ("dog");
				} 
			} 
		} 
	}
	void OnTriggerEnter2D(Collider2D col) {
		GameObject obj = col.gameObject;

		if (obj.GetComponent<PlayerController>())
		{
			playerInRange = true;
		}

	}



	void OnTriggerExit2D(Collider2D col)
	{
			playerInRange = false;
	}

	/*public void deactivateDogs() {
		// deactivate dogs
		playerInRange = false;
		//anim.SetBool("Running", false);
		anim.SetBool("ChasingLeft", false);
		anim.SetBool("ChasingRight", false);
		playerInRange = false;
		}*/
				



}
