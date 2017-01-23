using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds;
	[SerializeField]
	private string nextScene;
	private Text displayText;
	private bool levelFinished;
	private SceneLoader loader;
	private bool started;
	private float secondsRemaining;

	// Use this for initialization
	void Start () {
		started = false;
		this.loader = FindObjectOfType<SceneLoader> ();
		this.levelFinished = false;
		this.displayText = GameObject.Find("Canvas/Timer").GetComponent<Text>();
		this.secondsRemaining = this.levelSeconds;
	}

	public void StartTimer() {
		started = true;
	}
	// Update is called once per frame
	void Update () {
		if (started) {
			secondsRemaining -= Time.deltaTime;
			if (!this.levelFinished) {
				this.displayText.text = "Time: " + ((int)secondsRemaining).ToString ();
			} else {
				OnFinish ();
			}
			if (secondsRemaining <= 0) {
				this.levelFinished = true;
			}
		}

	}
	private void OnFinish() {
		this.loader.LoadImmediate ();
	}
}
	
