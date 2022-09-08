using System.Collections;
using TMPro;
using UnityEngine;

public class RandomCounter : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI text;
    private float count;
    private bool onCounting = true;

    private void Start() {
        count = Random.Range(-90f, 90f);
        StartCoroutine(RotatorTimer());
    }

    private void Update() {
        Counter();
    }

    private void Counter() {
        if (onCounting) {
            count -= (count * Time.deltaTime);
            text.text = count.ToString();

        }
        else {
            count = Random.Range(-90f, 90f);
            onCounting = true;
            StartCoroutine(RotatorTimer());
        }
    }

    private IEnumerator RotatorTimer() {
        yield return new WaitForSeconds(Random.Range(5f, 7f));
        onCounting = false;
    }
}
