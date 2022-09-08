using UnityEngine;

public class ExtraHealth : MonoBehaviour {
    [SerializeField] private float extraHealthValue;
    
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.TryGetComponent(out PlayerHealth playerHealth)) {
            playerHealth.ExtraHealthPickUp(extraHealthValue);
            Destroy(gameObject);
            Debug.Log("Pick Up Extra Health!");
        }
    }
}
