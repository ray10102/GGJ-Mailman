using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string BACKGROUND_VOLUME_KEY = "background_volume";
    const string SFX_VOLUME_KEY = "sfx_volume";
	const string USE_SUBTITLES_KEY = "subtitles_on_flag";
	const string SUBTITLE_FONT_TYPE_KEY = "font_type";
	const string SUBTITLE_FONT_SIZE_KEY = "font_size";
	const string SUBTITLE_FONT_TEXT_COLOR_KEY_R = "font_text_color_r";
	const string SUBTITLE_FONT_TEXT_COLOR_KEY_G = "font_text_color_g";
	const string SUBTITLE_FONT_TEXT_COLOR_KEY_B = "font_text_color_b";
	const string SUBTITLE_FONT_TEXT_COLOR_KEY_ALPHA = "font_text_color_alpha";

	const string SUBTITLE_BACKGROUND_COLOR_KEY_R = "background_color_r";
	const string SUBTITLE_BACKGROUND_COLOR_KEY_G = "background_color_b";
	const string SUBTITLE_BACKGROUND_COLOR_KEY_B = "background_color_g";
	const string SUBTITLE_BACKGROUND_COLOR_KEY_ALPHA = "background_color_alpha";


    const string LEVEL_KEY = "level_unlocked_";

	public static void SetMusicVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(BACKGROUND_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Music volume out of range");
        }
    }

	public static float GetMusicVolume() {
        return PlayerPrefs.GetFloat(BACKGROUND_VOLUME_KEY);
    }


	//This handles the subtitles on pref

	public static void SetUseSubtitles(int flag) {
		if (flag == 0 || flag == 1) {
			PlayerPrefs.SetInt(USE_SUBTITLES_KEY, flag);
		} else {
			Debug.LogError("Use Subtitles flag was not 0 or 1");
		}
	}

	public static int GetUseSubtitlesFlag() {
		return PlayerPrefs.GetInt(USE_SUBTITLES_KEY);
	}

	//This handles the font type pref
	public static void SetSubtitlesFontType(int fontindx) {
		PlayerPrefs.SetInt(SUBTITLE_FONT_TYPE_KEY, fontindx);
	}

	public static int GetSubtitlesFontTypeindx() {
		return PlayerPrefs.GetInt(SUBTITLE_FONT_TYPE_KEY);
	}


	//This handles the font size pref
	public static void SetSubtitlesFontSize(float fontSize) {
		PlayerPrefs.SetInt(SUBTITLE_FONT_SIZE_KEY, (int) fontSize);

	}

	public static int GetSubtitlesFontSize() {
		return PlayerPrefs.GetInt(SUBTITLE_FONT_SIZE_KEY);
	}


	//This handles the font size pref
	public static void SetSubtitlesFontTextColor(float r,float g, float b, float a) {
		if (r >= 0f && g >= 0f && b >= 0f && r <= 1f && g <= 1f && b <= 1f) {
			PlayerPrefs.SetFloat (SUBTITLE_FONT_TEXT_COLOR_KEY_R, r);
			PlayerPrefs.SetFloat (SUBTITLE_FONT_TEXT_COLOR_KEY_G, g);
			PlayerPrefs.SetFloat (SUBTITLE_FONT_TEXT_COLOR_KEY_B, b);
			PlayerPrefs.SetFloat (SUBTITLE_FONT_TEXT_COLOR_KEY_ALPHA, a);

		} else {
			Debug.LogError("Font Text Color was invalid");

		}
	}

	public static float[] GetSubtitlesFontTextColor() {
		float[] rgba = {PlayerPrefs.GetFloat(SUBTITLE_FONT_TEXT_COLOR_KEY_R),PlayerPrefs.GetFloat(SUBTITLE_FONT_TEXT_COLOR_KEY_G),PlayerPrefs.GetFloat(SUBTITLE_FONT_TEXT_COLOR_KEY_B),PlayerPrefs.GetFloat(SUBTITLE_FONT_TEXT_COLOR_KEY_ALPHA)};

		return rgba;
	}


	//This handles the font size pref
	public static void SetSubtitlesBackgroundColor(float r,float g, float b, float a) {
		if (r >= 0f && g >= 0f && b >= 0f && r <= 1f && g <= 1f && b <= 1f) {
			PlayerPrefs.SetFloat (SUBTITLE_BACKGROUND_COLOR_KEY_R, r);
			PlayerPrefs.SetFloat (SUBTITLE_BACKGROUND_COLOR_KEY_G, g);
			PlayerPrefs.SetFloat (SUBTITLE_BACKGROUND_COLOR_KEY_B, b);
			PlayerPrefs.SetFloat (SUBTITLE_BACKGROUND_COLOR_KEY_ALPHA, a);


		} else {
			Debug.LogError("Background Color was invalid");
		}
	}

	public static float[] GetSubtitlesBackgroundColor() {
		float[] rgba = {PlayerPrefs.GetFloat(SUBTITLE_BACKGROUND_COLOR_KEY_R),PlayerPrefs.GetFloat(SUBTITLE_BACKGROUND_COLOR_KEY_G),PlayerPrefs.GetFloat(SUBTITLE_BACKGROUND_COLOR_KEY_B),PlayerPrefs.GetFloat(SUBTITLE_BACKGROUND_COLOR_KEY_ALPHA)};
		return rgba;
	}


    public static void UnlockLevel(int level) {
        if (level <= Application.levelCount - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // using 1 for true
        } else {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level) {
        if (level <= Application.levelCount - 1) {
            int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
            return (levelValue == 1);
        } else {
            Debug.LogError("Trying to query level not in bui;ld order");
            return false;
        }
    }

    public static void SetSFXVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        } else {
            Debug.LogError("SFX volume out of range");
        }
    }

    public static float GetSFXVolume() {
		return PlayerPrefs.GetFloat(SFX_VOLUME_KEY);
    }
}