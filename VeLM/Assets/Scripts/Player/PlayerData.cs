[System.Serializable]
public class PlayerData {
    private string lastSceneNameData;
    private float playerPositionX;
    private float playerPositionY;
    private float currentHealthData;
    private float currentExtraHealthData;
    private float currentManaData;

    public string LastSceneNameData {
        get { return lastSceneNameData; }
    }
    public float PlayerPositionX {
        get { return playerPositionX; }
    }
    public float PlayerPositionY {
        get { return playerPositionY; }
    }
    public float CurrentHealthData {
        get { return currentHealthData; }
    }
    public float CurrentExtraHealthData {
        get { return currentExtraHealthData; }
    }
    public float CurrentManaData {
        get { return currentManaData; }
    }

    public void PackingData(Player player, PlayerHealth playerHealth) {
        lastSceneNameData = player.gameObject.scene.name;
        playerPositionX = player.transform.position.x;
        playerPositionY = player.transform.position.y;
        currentHealthData = playerHealth.CurrentHealth;
        currentExtraHealthData = playerHealth.CurrentExtraHealth;
        currentManaData = player.CurrentMana;
    }
}
