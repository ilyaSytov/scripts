using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsSelecter : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler, IPointerClickHandler {

    [SerializeField] private Button button;
    [SerializeField] private Sprite[] buttonStateSprites;
    [SerializeField] private SpriteState selectedSpriteState;
    [SerializeField] private AudioClip[] buttonClips;
    private EventSystem eventSystem;
    private SpriteState normalSpriteState;
    private AudioSource audioSource;
    private OptionsSelecter[] selecterButtons;
    private Image buttonImage;
    private bool currentButton = false;
    private bool firstSelect = false;

    private void Awake() {
        eventSystem = FindObjectOfType<EventSystem>();
        normalSpriteState = button.spriteState;
        audioSource = GetComponent<AudioSource>();
        buttonImage = button.GetComponent<Image>();
        buttonImage.color = new Vector4(255, 255, 255, 0);
        selecterButtons = FindObjectsOfType<OptionsSelecter>();
        if (eventSystem.firstSelectedGameObject == gameObject) {
            button.Select();
            buttonImage.color = new Vector4(255, 255, 255, 255);
            currentButton = true;
            buttonImage.sprite = buttonStateSprites[2];
            button.spriteState = selectedSpriteState;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        MouseClick();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData) {
        if (firstSelect == false) {
            firstSelect = true;
            button.Select();
            buttonImage.color = new Vector4(255, 255, 255, 255);
        }
        else {
            button.Select();
            buttonImage.color = new Vector4(255, 255, 255, 255);
            audioSource.clip = buttonClips[1];
            audioSource.Play();
        }
    }

    public void OnDeselect(BaseEventData eventData) {
        if (currentButton != true) {
            Deselecter();
        }
    }

    public void Deselecter() {
        buttonImage.color = new Vector4(255, 255, 255, 0);
    }

    public void MouseClick() {
        foreach (OptionsSelecter button in selecterButtons) {
            button.Deselecter();
            buttonImage.sprite = buttonStateSprites[0];
            button.GetComponent<Button>().spriteState = normalSpriteState;
            button.currentButton = false;
        }
        currentButton = true;
        buttonImage.sprite = buttonStateSprites[2];
        button.spriteState = selectedSpriteState;
        button.Select();
        buttonImage.color = new Vector4(255, 255, 255, 255);
        audioSource.clip = buttonClips[0];
        audioSource.Play();
    }

}