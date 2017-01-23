using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleManager : MonoBehaviour {
	public bool ingameflag;
	public int lifetime;//in frames

	private int currlifetime;//in frames

	private float[] textColorRGBA;
	private float[] backgroundColorRGBA;
	private float fontSize;
	private GameObject data_crap;
	private GameObject background;
	private GameObject label;
	private Font[] selectable_fonts;
	private Color textColor;
	private Color backgroundColor;
	private float alphatext;
	private float alphaBackgroud;
	private int currLife;
	private bool countLife;
	const  float pixelWidthOffset = 200;
	const float PixelHeightOffset = 200;

	// Use this for initialization
	void Start () {
		//Get the objects for fonts
		data_crap = GameObject.Find("GlobalDataCrap");
		Debug.Log (data_crap);

		//Assumed Order
		background = gameObject.transform.FindChild("Background").gameObject;
		label = background.transform.FindChild("Label").gameObject;
		label.GetComponent<UnityEngine.UI.Text> ().resizeTextMaxSize = 1; 
		//text = gameObject.transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
		//Update based on PlayerPrefs

		//Get color for subtitle text
		textColorRGBA = PlayerPrefsManager.GetSubtitlesFontTextColor ();
		alphatext = textColorRGBA [3];//Get alpha for text
		backgroundColorRGBA = PlayerPrefsManager.GetSubtitlesBackgroundColor ();
		alphaBackgroud = backgroundColorRGBA [3];

		//Get if the subtitles are enabled
		if (PlayerPrefsManager.GetUseSubtitlesFlag() == 0 || (ingameflag && !countLife)){alphatext =0f;alphaBackgroud = 0f;};


		if (countLife) {

			currLife = currLife + 1;
			if (currLife > currlifetime) {
				currLife = 0;
				countLife = false;
				currlifetime = lifetime;

			}
		}
		//Debug.Log (PlayerPrefsManager.GetUseSubtitlesFlag ());
		//.isOn = (isenabled == 1);

		//Set font

		FontLoader fl = data_crap.GetComponent<FontLoader>();
		selectable_fonts =fl.selectable_fonts;

		label.GetComponent<UnityEngine.UI.Text>().font =selectable_fonts[PlayerPrefsManager.GetSubtitlesFontTypeindx()];
		//Adjust background to match text size
		background.GetComponent<RectTransform> ().sizeDelta = new Vector2 (label.GetComponent<UnityEngine.UI.Text>().preferredWidth * 1.20f,label.GetComponent<UnityEngine.UI.Text>().preferredHeight * 1.20f);
		//background.GetComponent<RectTransform> ().sizeDelta = new Vector2 (label.GetComponent<UnityEngine.UI.Text>().preferredWidth +pixelWidthOffset,label.GetComponent<UnityEngine.UI.Text>().preferredHeight +PixelHeightOffset);

		Debug.Log (label.GetComponent<UnityEngine.UI.Text>().preferredWidth);



		//Get slider value
		label.GetComponent<UnityEngine.UI.Text> ().fontSize = PlayerPrefsManager.GetSubtitlesFontSize();


		textColor = new Color(textColorRGBA[0], textColorRGBA[1], textColorRGBA[2],alphatext);

		label.GetComponent<UnityEngine.UI.Text> ().color = textColor;
		//Get color for subtitle background

		backgroundColor = new Color(backgroundColorRGBA[0], backgroundColorRGBA[1], backgroundColorRGBA[2],alphaBackgroud);
		background.GetComponent<UnityEngine.UI.Image> ().color = backgroundColor;

	}


	public void broadcast_subtitle(string text)
	{

		currlifetime = lifetime;
		currLife = 0;//set life to zero
		//set text
		label = gameObject.transform.FindChild("Background").gameObject.transform.FindChild("Label").gameObject;
		label.GetComponent<UnityEngine.UI.Text> ().text = text;
		//Debug.Log (label.GetComponent<UnityEngine.UI.Text> ().text);
		//Debug.Log (		55);

		//turn on subtitle
		countLife = true;

	}

	public void broadcast_subtitle(string text,int inputLifetime)
	{
		currlifetime = inputLifetime;

		this.broadcast_subtitle (text);
	}



}
