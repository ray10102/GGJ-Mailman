using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBreakdown : MonoBehaviour {
	private Text breakdownText;

	// Use this for initialization
	void Start () {
		this.breakdownText = GameObject.Find ("Canvas/Breakdown").GetComponent<Text> ();
		string line1 = "Number of Deliveries: " + ScoreManager.getScore ().ToString() + "\n";
		//string line2 = "Number of Deliveries Possible: " + scoreManager.getMaxScore ().ToString() + "\n";
		//string line3 = "Your Rating: " + this.Rating();
		this.breakdownText.text = line1;

	}
	
//	private string Rating() {
//		float fraction = scoreManager.getScore () / scoreManager.getMaxScore ();
//		string grade;
//		if (fraction == 1) {
//			grade = "A+";
//		} else if (fraction >= 0.9) {
//			grade = "A";
//		} else if (fraction >= 0.8) {
//			grade = "B";
//		} else if (fraction >= 0.7) {
//			grade = "C";
//		} else {
//			grade = "F";
//		}
//		return grade;
//	}
}
