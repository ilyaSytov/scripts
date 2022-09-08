using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsManager : MonoBehaviour {

    public void LoadingScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitButton() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif    
    }
}
