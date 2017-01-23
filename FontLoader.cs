using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontLoader : MonoBehaviour {
	
	public Font[] selectable_fonts;


	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
