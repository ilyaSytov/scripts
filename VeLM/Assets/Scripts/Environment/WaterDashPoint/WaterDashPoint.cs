using UnityEngine;

public class WaterDashPoint : MonoBehaviour {
    [SerializeField] private float dashForce = 2f;
    [SerializeField] private WaterDashPointSprite pointSprite;
    [SerializeField] private GameObject arrowSprite;

    private void Start() {
        arrowSprite.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<Player>()) {
            arrowSprite.SetActive(true);
            pointSprite.IncreaseRotation();
            collider.GetComponent<WaterDashPointInstancing>().DashPointInstance = gameObject.GetComponent<WaterDashPoint>();
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out Player player)) {
            arrowSprite.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z), gameObject.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.GetComponent<Player>()) {
            arrowSprite.SetActive(false);
            pointSprite.DecreaseRotation();
            collider.GetComponent<WaterDashPointInstancing>().DashPointInstance = null;
        }
    }

    public void DashingPlayer(Rigidbody2D playerRb) {
            Vector2 dashDirection = (gameObject.transform.position - playerRb.transform.position).normalized;
            playerRb.velocity = dashDirection * dashForce;
    }
}
