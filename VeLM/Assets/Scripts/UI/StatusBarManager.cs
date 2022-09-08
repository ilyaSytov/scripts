using UnityEngine;
using UnityEngine.UI;

public class StatusBarManager : MonoBehaviour {
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider healthExtraBar;
    [SerializeField] private Slider manaBar;

    private PlayerHealth playerHealth;
    private Player playerMana;

    private void Awake() {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        playerMana = GameObject.FindObjectOfType<Player>();
    }

    private void Start() {
        healthBar.maxValue = playerHealth.MaxHealth;
        healthExtraBar.maxValue = playerHealth.MaxExtraHealth;
        manaBar.maxValue = playerMana.MaxManaPool;
        UpdateBarValues();
    }

    private void OnEnable() {
        playerHealth.HealthChanged += UpdateBarValues;
    }

    private void OnDisable() {
        playerHealth.OnDeathAction -= UpdateBarValues;
    }

    private void UpdateBarValues() {
        healthBar.value = playerHealth.CurrentHealth;
        healthExtraBar.value = playerHealth.CurrentExtraHealth;
        manaBar.value = playerMana.CurrentMana;
        UpdateExtraHealthBarState();
        print(playerHealth.CurrentExtraHealth);
    }

    private void UpdateExtraHealthBarState() {
        if (healthExtraBar.value <= 0) {
            healthExtraBar.gameObject.SetActive(false);
        }
        else {
            healthExtraBar.gameObject.SetActive(true);
        }
    }
}
