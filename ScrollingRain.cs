using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingRain : MonoBehaviour {

	private PlayerController player;
	private float horizontal_Size;

	// Use this for initialization
	protected void Start () {
		this.player = FindObjectOfType<PlayerController> ();
		ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
		var sh = ps.shape;
		horizontal_Size = sh.box.x;

	}

	// Update is called once per frame
	void Update () {
		Vector3 change = this.player.transform.position - this.transform.position;
		Debug.Log (change);
		if (change.x > horizontal_Size) {
			this.transform.Translate (new Vector3 (2*horizontal_Size, 0f, 0f));
		}
		else if(change.x < -horizontal_Size){
			this.transform.Translate (new Vector3 (-2*horizontal_Size, 0f, 0f));
		}
	}
}
