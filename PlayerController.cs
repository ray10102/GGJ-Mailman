using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private float speed;
	private bool canMove;
	private bool mailboxTrigger;
	private Animator anim;

	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animator> ();
        speed = 2f;
        canMove = true;
        mailboxTrigger = false;
	}

	// Update is called once per frame
	void Update () {
        // key handlers
        if (canMove) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }

		if (mailboxTrigger) {
			if (Input.GetKeyDown (KeyCode.Space)) {
                canMove = false;
				//TODO: write method that changes the mailbox isEmpty boolean

				// delivery event happens
				//anim.SetTrigger ("Delivery Trigger");
				//box.isEmpty = false;
				//  increment score
				Debug.Log ("delivery triggered");
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		
		GameObject obj = col.gameObject;
		Debug.Log ("collided");
		// check if collision was with a mailbox 
		if (obj.GetComponent<Mailbox> ()) {
			Debug.Log ("collided with mailbox");
			this.mailboxTrigger = true;
		}
	}

    void OnTriggerExit2D (Collider2D col) {
        GameObject obj = col.gameObject;

        if (obj.GetComponent<Mailbox>()) {
            this.mailboxTrigger = false;
        }
    }
}
