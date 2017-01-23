using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

	private PlayerController player;
	private Vector3 offset;

	// Use this for initialization
	protected void Start () {
		this.player = FindObjectOfType<PlayerController> ();
		this.offset = this.transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		Vector3 change = this.player.transform.position - this.transform.position + this.offset;
		this.transform.Translate (change);
	}
}
