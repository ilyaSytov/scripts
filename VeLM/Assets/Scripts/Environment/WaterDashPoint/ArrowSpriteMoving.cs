using UnityEngine;

public class ArrowSpriteMoving : MonoBehaviour {
    [SerializeField] private float arrowMovingSpeed = 0.025f;

    private void Update() {
        transform.localPosition = new Vector3(Mathf.PingPong(Time.time * arrowMovingSpeed, 0.015f), 0, 0);
    }
}
