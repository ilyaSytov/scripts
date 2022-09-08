using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundSettingManager : MonoBehaviour {
    [SerializeField] private GameObject backPanel;
    [SerializeField] private Slider musicSlader;
    [SerializeField] private Slider effectSlader;
    [SerializeField] private Slider dialogeSlader;
    [SerializeField] private AudioMixer audioMixer;
    private bool settingsChanged;
    private float musicVolumeValue;
    private float effectsVolumeValue;
    private float dialogeVolumeValue;

    private void Awake() {
        musicSlader.value = PlayerPrefsManager.GetMusicVolumePref();
        effectSlader.value = PlayerPrefsManager.GetEffectsVolumePref();
        dialogeSlader.value = PlayerPrefsManager.GetDialogeVolumePref();
        settingsChanged = false;
        backPanel.SetActive(false);
    }

    public void SetMusicVolume(float value) {
        musicVolumeValue = value;
        audioMixer.SetFloat("musicVolume", value);
        settingsChanged = true;
    }

    public void SetEffectVolume(float value) {
        effectsVolumeValue = value;
        audioMixer.SetFloat("effectsVolume", value);
        settingsChanged = true;
    }

    public void SetDialogeVolume(float value) {
        dialogeVolumeValue = value;
        audioMixer.SetFloat("dialogeVolume", value);
        settingsChanged = true;
    }

    public void ApplySettings() {
        PlayerPrefsManager.SetMusicVolumePref(musicVolumeValue);
        PlayerPrefsManager.SetEffectsVolumePref(effectsVolumeValue);
        PlayerPrefsManager.SetDialogeVolumePref(dialogeVolumeValue);
        settingsChanged = false;
    }

    public void BackButton(string sceneName) {
        if (settingsChanged) {
            backPanel.SetActive(true);
        }
        else {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void YesButton() {
        ApplySettings();
        backPanel.SetActive(false);
        settingsChanged = false;
        BackButton("SettingsMenu");
    }

    public void NoButton() {
        backPanel.SetActive(false);
        settingsChanged = false;
        BackButton("SettingsMenu");
    }
}
