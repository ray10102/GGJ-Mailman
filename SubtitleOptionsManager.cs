using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubtitleOptionsManager : MonoBehaviour {

	public Slider FontSizeSlider;
	public Slider TextColorSliderR;
	public Slider TextColorSliderG;
	public Slider TextColorSliderB;
	public Slider TextColorSliderAlpha;

	public Slider BackgroundColorSliderR;
	public Slider BackgroundColorSliderG;
	public Slider BackgroundColorSliderB;
	public Slider BackgroundColorSliderAlpha;

	public Dropdown FontTypeDropdown;
	public Toggle SubtitlesEnableToggle;

	public Font[] selectable_fonts;
	public LevelManager levelManager;


	//private MusicManager musicManager;


	// Use this for initialization
	void Start () {
		//	musicManager = GameObject.FindObjectOfType<MusicManager> ();

		//Get if the subtitles are enabled
		int isenabled = PlayerPrefsManager.GetUseSubtitlesFlag();
		SubtitlesEnableToggle.isOn = (isenabled == 1);

		//Set font
		GameObject data_crap = GameObject.Find("GlobalDataCrap");

		FontLoader fl = data_crap.GetComponent<FontLoader>();
		selectable_fonts =fl.selectable_fonts;
		update_fonts();

		//Get slider value
		FontSizeSlider.value = PlayerPrefsManager.GetSubtitlesFontSize();

		//Get color for subtitle text
		float[] textColorRGB = PlayerPrefsManager.GetSubtitlesFontTextColor ();
		TextColorSliderR.value = textColorRGB[0];
		TextColorSliderG.value = textColorRGB[1];
		TextColorSliderB.value = textColorRGB[2];
		TextColorSliderAlpha.value = textColorRGB[3];


		//Get color for subtitle background
		float[] BackgroundColorRGB = PlayerPrefsManager.GetSubtitlesBackgroundColor ();
		BackgroundColorSliderR.value = BackgroundColorRGB[0];
		BackgroundColorSliderG.value = BackgroundColorRGB[1];
		BackgroundColorSliderB.value = BackgroundColorRGB[2];
		BackgroundColorSliderAlpha.value = BackgroundColorRGB[3];


	}

	// Update is called once per frame
	void Update () {
		//musicManager.ChangeVolume (MusicVolumeSlider.value);
		//musicManager.ChangeVolume (SFXSlider.value);

		//updating the "example"


		//Set  subtitles are enabled flag
		if (SubtitlesEnableToggle.isOn){
			PlayerPrefsManager.SetUseSubtitles(1);
		}else{PlayerPrefsManager.SetUseSubtitles(0);}


		//Set font
		PlayerPrefsManager.SetSubtitlesFontType(FontTypeDropdown.value);

		//Set font size
		PlayerPrefsManager.SetSubtitlesFontSize(FontSizeSlider.value);

		//set color for subtitle text
		PlayerPrefsManager.SetSubtitlesFontTextColor(TextColorSliderR.value,TextColorSliderG.value,TextColorSliderB.value,	TextColorSliderAlpha.value);
	

		//Get color for subtitle background
		PlayerPrefsManager.SetSubtitlesBackgroundColor(BackgroundColorSliderR.value,BackgroundColorSliderG.value,BackgroundColorSliderB.value,BackgroundColorSliderAlpha.value);


	}

	public void SaveAndExit () {




//		levelManager.LoadLevel ("01a Start Menu");
	}

	public void SetDefaults () {

		//Get if the subtitles are enabled
		SubtitlesEnableToggle.isOn = false;

		update_fonts();

		//Get slider value
		FontSizeSlider.value = PlayerPrefsManager.GetSubtitlesFontSize();

		//Get color for subtitle text
		float[] textColorRGB = PlayerPrefsManager.GetSubtitlesFontTextColor ();
		TextColorSliderR.value = 1f;
		TextColorSliderG.value = 1f;
		TextColorSliderB.value = 1f;
		TextColorSliderAlpha.value = 1f;


		//Get color for subtitle background
		float[] BackgroundColorRGB = PlayerPrefsManager.GetSubtitlesBackgroundColor ();
		BackgroundColorSliderR.value = 0f;
		BackgroundColorSliderG.value = 0f;
		BackgroundColorSliderB.value = 0f;
		BackgroundColorSliderAlpha.value = .8f;



	}

	private void update_fonts()
	{
		//Set font
		//clear the options
		FontTypeDropdown.options.Clear ();
		//add the fonts
		foreach (Font f in selectable_fonts)
		{
			FontTypeDropdown.options.Add (new Dropdown.OptionData (){text = f.name});
		}
		//Refresh the gui
		FontTypeDropdown.value = 1;
		FontTypeDropdown.value = 0;

	}

	public void Deactivate()
	{
		gameObject.SetActive(false);

	}

	public void Activate()
	{
		gameObject.SetActive(true);

	}



}
