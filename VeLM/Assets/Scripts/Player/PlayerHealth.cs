using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable {
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxExtraHealth;
    private float currentExtraHealth;
    private float currentHealth;
    private bool canTakeDamage = true;
    public UnityAction OnDeathAction;
    public UnityAction HealthChanged;
    public float MaxHealth => maxHealth;
    public float MaxExtraHealth => maxExtraHealth;
    public float CurrentHealth {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    public float CurrentExtraHealth {
        get { return currentExtraHealth; }
        set { currentExtraHealth = value; }
    }

    void Awake() {
        currentHealth = maxHealth;
        currentExtraHealth = 0;
    }

    public TakeDamageResult TakeDamage(float damage, Vector2 impulse = new Vector2()) {
        if (!canTakeDamage) {
            TakeDamageResult noDamageResult = new TakeDamageResult();
            noDamageResult.isStillAlive = true;
            return noDamageResult;
        }
        if (currentExtraHealth > 0) {
            TakeDamageResult resultExt = new TakeDamageResult();
            if ((currentExtraHealth - damage) < 0) {
                currentHealth = (currentHealth + currentExtraHealth) - damage;
                currentExtraHealth = 0;
                OnHealthChanged();
                Debug.Log($"Player took {damage} damage, {currentHealth}/{maxHealth} health now");
                if (currentHealth <= 0) {
                    OnDeath();
                    resultExt.isStillAlive = false;
                    return resultExt;
                }
                resultExt.isStillAlive = true;
                return resultExt;
            }
            currentExtraHealth -= damage;
            OnHealthChanged();
            Debug.Log($"Player took {damage} damage, {currentHealth + currentExtraHealth}/{maxHealth + maxExtraHealth} health now");
            resultExt.isStillAlive = true;
            return resultExt;

        }

        currentHealth -= damage;
        OnHealthChanged();
        Debug.Log($"Player took {damage} damage, {currentHealth}/{maxHealth} health now");
        TakeDamageResult result = new TakeDamageResult();
        if (currentHealth <= 0) {
            OnDeath();
            result.isStillAlive = false;
            return result;
        }
        result.isStillAlive = true;
        return result;
    }

    public void EnableHyperArmor() {
        canTakeDamage = false;
    }

    public void DisableHyperArmor() {
        canTakeDamage = true;
    }

    public void OnDeath() {
        OnDeathAction?.Invoke();
    }

    public void OnRespawn() {
        currentHealth = maxHealth;
        OnHealthChanged();
    }
    public void OnHealthChanged() {
        HealthChanged?.Invoke();
    }

    public void Heal(float healingValue) {
        if ((currentHealth + healingValue) > maxHealth) {
            currentHealth = maxHealth;
        }
        else {
            currentHealth += healingValue;
        }
        OnHealthChanged();
    }

    public void ExtraHealthPickUp(float extraHealthValue) {
        if (currentHealth != maxHealth) {
            if ((extraHealthValue - (maxHealth - currentHealth)) <= 0) {
                currentHealth += extraHealthValue;
                extraHealthValue = 0;
                OnHealthChanged();
                return;
            }
            else {
                extraHealthValue = extraHealthValue - (maxHealth - currentHealth);
                currentHealth = currentHealth + (maxHealth - currentHealth);
                OnHealthChanged();
            }
        }
        if ((currentExtraHealth + extraHealthValue) > maxExtraHealth) {
            currentExtraHealth = maxExtraHealth;
            OnHealthChanged();
        }
        else {
            currentExtraHealth += extraHealthValue;
            OnHealthChanged();
        }
        Debug.Log(currentExtraHealth);
    }
}
