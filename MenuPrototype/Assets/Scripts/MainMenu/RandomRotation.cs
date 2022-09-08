using System.Collections;
using UnityEngine;

public class RandomRotation : MonoBehaviour {
    [SerializeField] private RectTransform rotatedElement;
    private float angle;
    private bool onRotating = true;

    private void Start() {
        angle = Random.Range(-90f, 90f);
        StartCoroutine(RotatorTimer());
    }

    private void Update() {
        Rotator();
    }

    private void Rotator() {
        if (onRotating) {
            angle -= (angle * Time.deltaTime);
            rotatedElement.Rotate(0, 0, angle * Time.deltaTime);
        }
        else {
            angle = Random.Range(-90f, 90f);
            onRotating = true;
            StartCoroutine(RotatorTimer());
        }
    }

    private IEnumerator RotatorTimer() {
        yield return new WaitForSeconds(Random.Range(5f, 7f));
        onRotating = false;
    }
}
