using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsSettingSliderField : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler {

    [SerializeField] private Button button;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private float sliderStartValue;
    [SerializeField] private string valuePrefix;
    [SerializeField] private bool valueHavePrefix;
    private SpriteState spriteState;
    private DefaultInputActions input;
    private bool isSelected;
    private bool sliderPressed = false;
    private AudioSource audioSource;

    private void Awake() {
        spriteState = button.spriteState;
        input = new DefaultInputActions();
        audioSource = GetComponent<AudioSource>();
        slider = gameObject.GetComponentInChildren<Slider>();
        slider.value = sliderStartValue;
        SliderValueChange(slider.value);
    }

    private void OnEnable() {
        input.Enable();
    }

    private void OnDisable() {
        input.Disable();
    }

    private void FixedUpdate() {
        Vector2 inputAxis = input.UI.Navigate.ReadValue<Vector2>();

        if (inputAxis.x > 0 && isSelected) {
            if (sliderPressed == true) {
                sliderPressed = false;
                audioSource.Play();
            }
            slider.value += 1;
        }

        if (inputAxis.x < 0 && isSelected) {
            if (sliderPressed == true) {
                sliderPressed = false;
                audioSource.Play();
            }
            slider.value -= 1;
        }

        if (inputAxis.x == 0 && isSelected && input.UI.Click.ReadValue<float>() == 0) {
            sliderPressed = true;
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

    public void SliderValueChange(float value) {
        if (input.UI.Click.ReadValue<float>() != 0 && sliderPressed == true) {
            button.Select();
            sliderPressed = false;
            audioSource.Play();
        }
        sliderText.text = value.ToString();
        if (valueHavePrefix) {
            sliderText.text = value.ToString() + valuePrefix;
        }
    }

}