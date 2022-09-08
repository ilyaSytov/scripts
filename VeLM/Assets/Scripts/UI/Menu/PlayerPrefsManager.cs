using UnityEngine;

public class PlayerPrefsManager {
    private const string LANGUAGE_KEY = "language";
    private const string RESOLUTION_KEY = "resolution";
    private const string MUSIC_VOLUME_KEY = "master_volume";
    private const string EFFECTS_VOLUME_KEY = "effects_volume";
    private const string DIALOGE_VOLUME_KEY = "dialoge_volume";
    private const string SAVE_PATH_KEY = "save_path";
    private const string INPUT_ASSET_KEY = "input_asset";

    public static void SetLanguagePref(int languageIndex) {
        PlayerPrefs.SetInt(LANGUAGE_KEY, languageIndex);
    }

    public static int GetLanguagesPref() {
        return PlayerPrefs.GetInt(LANGUAGE_KEY);
    }

    public static void SetResolutionPref(int resolutionIndex) {
        PlayerPrefs.SetInt(RESOLUTION_KEY, resolutionIndex);
    }

    public static int GetResolutionPref() {
        return PlayerPrefs.GetInt(RESOLUTION_KEY);
    }

    public static void SetMusicVolumePref(float musicVolumeIndex) {
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, musicVolumeIndex);
    }

    public static float GetMusicVolumePref() {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
    }

    public static void SetEffectsVolumePref(float effectsVolumeIndex) {
        PlayerPrefs.SetFloat(EFFECTS_VOLUME_KEY, effectsVolumeIndex);
    }

    public static float GetEffectsVolumePref() {
        return PlayerPrefs.GetFloat(EFFECTS_VOLUME_KEY);
    }

    public static void SetDialogeVolumePref(float dialogeVolumeIndex) {
        PlayerPrefs.SetFloat(DIALOGE_VOLUME_KEY, dialogeVolumeIndex);
    }

    public static float GetDialogeVolumePref() {
        return PlayerPrefs.GetFloat(DIALOGE_VOLUME_KEY);
    }

    public static void SetSavePathPref(string savePath) {
        PlayerPrefs.SetString(SAVE_PATH_KEY, savePath);
    }

    public static string GetSavePathPref() {
        return PlayerPrefs.GetString(SAVE_PATH_KEY);
    }

    public static void SetInputAssetPref(string inputAsset) {
        PlayerPrefs.SetString(INPUT_ASSET_KEY, inputAsset);
    }

    public static string GetInputAssetPref() {
        return PlayerPrefs.GetString(INPUT_ASSET_KEY);
    }

}
