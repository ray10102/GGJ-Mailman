using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour {

    public bool isEmpty = true;
    private Animator anim;

	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        GameObject obj = col.gameObject;

        if (obj.GetComponent<PlayerController>()) {
            //anim.SetBool("isOpen", true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        //anim.SetBool("isOpen", false);
    }
}
