using UnityEngine;

public class WaterDashPointSprite : MonoBehaviour {
    [Header("Point")]
    [SerializeField] private float activeRotatingSpeed = 90;
    [SerializeField] private float inactiveRotatingSpeed = 20;
    private float rotatingSpeed;

    private void Start() {
        rotatingSpeed = inactiveRotatingSpeed;
    }

    private void Update() {
        transform.Rotate(0, 0, -rotatingSpeed * Time.deltaTime);
    }

    public void IncreaseRotation() {
        rotatingSpeed = activeRotatingSpeed;
    }

    public void DecreaseRotation() {
        rotatingSpeed = inactiveRotatingSpeed;
    }

}
