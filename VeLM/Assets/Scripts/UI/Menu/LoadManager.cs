using System.IO;
using GoToApp.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour {
    [SerializeField] private GameObject loadButton;
    private PlayerData playerData;
    private Player player;
    private PlayerHealth playerHealth;

    private void Awake() {
        if (!File.Exists(PlayerPrefsManager.GetSavePathPref())) {
            loadButton.SetActive(false);
        }
        else {
            loadButton.SetActive(true);
        }
    }

    public void LoadGameData(GameObject currentPlayer) {
        player = currentPlayer.GetComponent<Player>();
        playerHealth = currentPlayer.GetComponent<PlayerHealth>();
        player.transform.position = new Vector2(playerData.PlayerPositionX, playerData.PlayerPositionY);
        playerHealth.CurrentHealth = playerData.CurrentHealthData;
        playerHealth.CurrentExtraHealth = playerData.CurrentExtraHealthData;
        player.CurrentMana = playerData.CurrentManaData;
        Destroy(gameObject);
    }

    public void LoadingGame() {
        if (File.Exists(PlayerPrefsManager.GetSavePathPref())) {
            playerData = BinarySerializer.Deserialize<PlayerData>(PlayerPrefsManager.GetSavePathPref());
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(playerData.LastSceneNameData);
        }
    }
}