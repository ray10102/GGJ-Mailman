using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class TypewriterEffect : MonoBehaviour 
{

	public Text txt;
    public string[] stories;

    private string story;

    void Awake() {
        txt = GetComponent<Text>();
        txt.text = "";
        story = stories[Random.Range(0, stories.GetLength(0))];
    

    // TODO: add optional delay when to start
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText() {
        foreach (char c in story) {
             txt.text += c;
            yield return new WaitForSeconds(0.15f);
        }
    }

}