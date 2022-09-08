using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsManagerOptions : MonoBehaviour, IPointerEnterHandler, ISelectHandler {

    [SerializeField] private Button button;
    [SerializeField] private AudioClip[] buttonSounds;
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void MouseClick() {
        audioSource.clip = buttonSounds[0];
        audioSource.Play();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData) {
        button.Select();
        audioSource.clip = buttonSounds[1];
        audioSource.Play();
    }

}