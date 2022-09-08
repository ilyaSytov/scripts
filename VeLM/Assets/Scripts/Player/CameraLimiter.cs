using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraLimiter : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer framingTransposer;
    private CinemachineConfiner confiner;
    private Player player;
    private bool playerAlreadyTurned;

    private void Awake() {
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        confiner = virtualCamera.GetComponent<CinemachineConfiner>();
        player = FindObjectOfType<Player>();
        var currentScene = SceneManager.GetActiveScene();
        OnSceneChanged(currentScene, currentScene);
    }

    private void OnEnable() {
        player.PlayerTurned += SwitchCameraOffet;
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDisable() {
        player.PlayerTurned -= SwitchCameraOffet;
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene current, Scene next) {
        if (FindObjectOfType<LevelBorder>() == null) {
            Debug.LogError("Lever border prefab not found.");
            return;
        }
        else {
            confiner.m_BoundingShape2D = FindObjectOfType<LevelBorder>().LevelCollider;
        }
    }

    private void SwitchCameraOffet(float direction) {
        if (direction > 0 && playerAlreadyTurned) {
            framingTransposer.m_TrackedObjectOffset.x = 1.8f;
            playerAlreadyTurned = false;
        }
        else if (direction < 0 && !playerAlreadyTurned) {
            framingTransposer.m_TrackedObjectOffset.x = -1.8f;
            playerAlreadyTurned = true;
        }
    }
}
