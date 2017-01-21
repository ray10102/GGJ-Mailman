using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string BACKGROUND_VOLUME_KEY = "background_volume";
    const string SFX_VOLUME_KEY = "sfx_volume";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(BACKGROUND_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(BACKGROUND_VOLUME_KEY);
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
        return PlayerPrefs.GetFloat(BACKGROUND_VOLUME_KEY);
    }
}