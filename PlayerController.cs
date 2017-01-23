using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;

	public bool canMove = true;
	// the object that the player has collided with, assumes player can't collided with more than 1 object at a time
	private GameObject collided;
	private Animator anim;
	private ScoreManager scoreManager;
	private StreetGenerator streetGenerator;
	// private float startLocation = 30;
	private optionspanel op;
	private SFXManager sfx;
	//private MusicManager music;

	void Awake ()	{
		op  = FindObjectOfType<optionspanel>();
		Debug.Log (op);

		op.Deactivate();
		gameObject.SetActive (true);
	}
	// Use this for initialization
	void Start () {
		speed = 5;
		anim = GetComponent<Animator> ();
		this.canMove = false;
		this.scoreManager = FindObjectOfType<ScoreManager> ();
		this.streetGenerator = FindObjectOfType<StreetGenerator> ();

		sfx = FindObjectOfType<SFXManager>();



    }

	// Update is called once per frame
	void Update () {
		// key handlers
		//Lets look for the escape key!!!
		if (Input.GetKey(KeyCode.Escape))
		{	//Someone should put some pausing logic here.....

			Debug.Log (op);

			//Load that panel!!!!!!!
			op.Activate();
		}

		float rightBoundary = this.streetGenerator.getStreetSize();
		float magnitude = speed * Time.deltaTime;
		if (canMove) {
			if (anim.GetBool ("rightWalking") && this.transform.position.x < rightBoundary) {
				transform.Translate (Vector2.right * magnitude);
			}
//			} else if (anim.GetBool ("leftWalking") && this.transform.position.x > 0) {
//				transform.Translate(Vector2.left * magnitude);
//				transform.localScale = new Vector3(-1, 1, 1);
//			} 

			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				anim.SetBool ("leftWalking", true);
			} else if (Input.GetKeyDown(KeyCode.RightArrow) ) {
				anim.SetBool ("rightWalking", true);
			}

			if (Input.GetKeyUp(KeyCode.LeftArrow)) {
				anim.SetBool ("leftWalking", false);
			} else if (Input.GetKeyUp(KeyCode.RightArrow) ) {
				anim.SetBool ("rightWalking", false);
			}

			if (Input.GetKeyUp (KeyCode.Z)) {
				anim.SetBool ("isWaving", true);
				LockMovement ();
			}
		}
		// check if the player has collided with something
		if (this.collided != null) {
			// try to get each available type then check if one succeeds
			Mailbox box = this.collided.GetComponent<Mailbox> ();
			Dogs dog = this.collided.GetComponent<Dogs> ();
			NPC NPC = this.collided.GetComponent<NPC> ();
			// interacting with a mailbox
			if (box != null && box.GetIsEmpty() && Input.GetKeyUp (KeyCode.Space)) {
				// delivery event happens
				//anim.SetTrigger ("Delivery Trigger");
				box.fill();
				this.incrementScore ();
				Debug.Log ("delivery triggered");
			} else if (dog != null && Input.GetKeyUp (KeyCode.Z)) {
				AlertSound ();
				Debug.Log ("waved at a dog");
				this.LockMovement ();
				anim.SetBool ("isWaving", true);
			} else if (NPC != null && !NPC.GetWaved() && Input.GetKeyUp (KeyCode.Z)) {
				Debug.Log ("waved at another person");
				GreetSound ();
				this.LockMovement ();
				anim.SetBool ("isWaving", true);
				NPC.WaveBack ();
				this.incrementScore ();
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		
		this.collided = col.gameObject;
	}

	void OnTriggerExit2D (Collider2D col) {
		this.collided = null;
	}
	// set the speed of the player
	public void setSpeed(float speed) {
		this.speed = speed;
	}

	public void EndWave() {
		anim.SetBool ("isWaving", false);
		Unlock ();
	}

	void incrementScore () {
 		this.scoreManager.incrementScore ();
	} 

	public void Deactivate()
	{
		GetComponent<Renderer> ().enabled = false;
		canMove = false;

	}

	public void Activate()
	{
		GetComponent<Renderer> ().enabled = true;
	}

	public void GreetSound ()
	{
		sfx.make_sfx ("greeting");
	}

	public void AlertSound ()
	{
		sfx.make_sfx ("alert");
	}
	public void Unlock() {
		canMove = true;
	}

    public void LockMovement () {
        canMove = false;
    }

    public void reactivateMovement() {
        canMove = true;
    }
}
