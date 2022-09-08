using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManagerMainMenu : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler {

    [SerializeField] private GameObject sideSelecter;
    [SerializeField] private Button button;
    [SerializeField] private AudioClip[] buttonSounds;
    private AudioSource audioSource;
    private bool firstSelect = false;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData) {
        if (firstSelect == false) {
            firstSelect = true;
            button.Select();
            sideSelecter.SetActive(true);
        }
        else {
            button.Select();
            sideSelecter.SetActive(true);
            audioSource.clip = buttonSounds[1];
            audioSource.Play();
        }
    }

    public void OnDeselect(BaseEventData eventData) {
        sideSelecter.SetActive(false);
    }

    public void ExitButton() {
        MouseClick();
        Debug.Log("Exit request.");
        Application.Quit();
    }

    public void MouseClick() {
        audioSource.clip = buttonSounds[0];
        audioSource.Play();
    }

}