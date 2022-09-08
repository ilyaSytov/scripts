using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsSettingArrowField : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler {

    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private string[] settingValues;
    [SerializeField] private int currentValue;
    private SpriteState spriteState;
    private DefaultInputActions input;
    private bool isSelected;
    private bool keyDown;
    private AudioSource audioSource;

    private void Awake() {
        spriteState = button.spriteState;
        input = new DefaultInputActions();
        audioSource = GetComponent<AudioSource>();
        valueText.text = settingValues[currentValue];
    }

    private void OnEnable() {
        input.Enable();
    }

    private void OnDisable() {
        input.Disable();
    }

    private void FixedUpdate() {
        Vector2 inputAxis = input.UI.Navigate.ReadValue<Vector2>();

        if (inputAxis.x == 1 && isSelected && keyDown == false) {
            keyDown = true;
            if (currentValue < settingValues.Length - 1) {
                currentValue++;
                valueText.text = settingValues[currentValue];
                audioSource.Play();
            }
        }

        if (inputAxis.x == -1 && isSelected && keyDown == false) {
            keyDown = true;
            if (currentValue > 0) {
                currentValue--;
                valueText.text = settingValues[currentValue];
                audioSource.Play();
            }
        }

        if (inputAxis.x == 0) {
            keyDown = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData) {
        spriteState.highlightedSprite = spriteState.selectedSprite;
        button.spriteState = spriteState;
        button.Select();
        audioSource.Play();
        isSelected = true;
    }

    public void OnDeselect(BaseEventData eventData) {
        if (input.UI.Click.ReadValue<float>() == 0) {
            spriteState.highlightedSprite = button.GetComponent<Image>().sprite;
            button.spriteState = spriteState;
        }
        isSelected = false;
    }

    public void ChangeFieldValue(bool positive) {
        button.Select();
        if (positive == true) {
            if (currentValue < settingValues.Length - 1) {
                currentValue++;
                valueText.text = settingValues[currentValue];
            }
        }
        if (positive == false) {
            if (currentValue > 0) {
                currentValue--;
                valueText.text = settingValues[currentValue];
            }
            audioSource.Play();
        }
    }
}