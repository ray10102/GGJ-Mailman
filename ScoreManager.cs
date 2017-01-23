using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class ScoreManager : MonoBehaviour {
	private static float score;
	private Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		this.scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.text = "Score: " + score.ToString ();
	}

	// increase the score by 1
	public void incrementScore() {
		score++;
	}

	public void Destroy() {
		Destroy(this);
	}

	public static float getScore() {
		return score;
	}
}
