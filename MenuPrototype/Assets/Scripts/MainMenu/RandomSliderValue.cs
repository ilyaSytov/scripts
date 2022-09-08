using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomSliderValue : MonoBehaviour {
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    private float value;
    private bool onValueChanging = true;

    private void Start() {
        value = Random.Range(-1, 1f);
        StartCoroutine(ValueChangeTimer());
    }

    private void Update() {
        ValueChanger();
    }

    private void ValueChanger() {
        if (onValueChanging) {
            value -= (value * Time.deltaTime);
            if (slider.value - (value * Time.deltaTime) > 1) {
                slider.value = 1;
                sliderText.text = slider.value.ToString();
            }
            else if (slider.value - (value * Time.deltaTime) < 0) {
                slider.value = 0;
                sliderText.text = slider.value.ToString();
            }
            else {
                slider.value = slider.value - (value * Time.deltaTime);
                sliderText.text = slider.value.ToString();
            }

        }
        else {
            value = Random.Range(-1, 1f);
            onValueChanging = true;
            StartCoroutine(ValueChangeTimer());
        }
    }

    private IEnumerator ValueChangeTimer() {
        yield return new WaitForSeconds(Random.Range(4f, 8f));
        onValueChanging = false;
    }
}
