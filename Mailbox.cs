using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour {

	private bool isEmpty;
    private Animator anim;
	private SFXManager sfx;

	// Use this for initialization
	void Start () {
		this.isEmpty = true;
        anim = GetComponent<Animator>();
		sfx = FindObjectOfType<SFXManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        GameObject obj = col.gameObject;

        if (obj.GetComponent<PlayerController>()) {
            anim.SetBool("mailboxOpen", true);
			sfx.make_sfx ("mailbox");
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        //anim.SetBool("isOpen", false);
    }

	public bool GetIsEmpty() {
		return this.isEmpty;
	}

	public void fill() {
		this.isEmpty = false;
	}
}
