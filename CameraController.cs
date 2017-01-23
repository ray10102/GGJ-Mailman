using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController :  Scrolling {

    private bool locked;
    private StreetGenerator sg;
    private Camera camera;
    private float cameraWidth;

    // Use this for initialization
    void Start() {
        this.locked = true;
        this.camera = GetComponent<Camera>();
        this.sg = FindObjectOfType<StreetGenerator>();
        this.cameraWidth = this.camera.orthographicSize * this.camera.aspect;
		base.Start ();
    }
}
