using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    [SerializeField] private Button upSnapButtonGameplay;
    [SerializeField] private Button bottomSnapButtonGameplay;
    [SerializeField] private Button upSnapButtonVideo;
    [SerializeField] private Button bottomSnapButtonVideo;
    [SerializeField] private Button gameplayButton;
    [SerializeField] private Button videoButton;
    [SerializeField] private Button[] otherButtons;
    [SerializeField] private GameObject gameplayGroup;
    [SerializeField] private GameObject videoGroup;
    [SerializeField] private GameObject otherGroup;
    private ButtonsManagerOptions[] bottomButtons;
    private OptionsSelecter[] upButtons;
    private Navigation gameplayNavigation;
    private Navigation videoNavigation;
    private Navigation otherNavigation;

    private void Awake() {
        bottomButtons = FindObjectsOfType<ButtonsManagerOptions>();
        upButtons = FindObjectsOfType<OptionsSelecter>();
        gameplayButton.onClick.AddListener(ChangeNavigationToGameplay);
        videoButton.onClick.AddListener(ChangeNavigationToVideo);
        foreach (Button otherButton in otherButtons) {
            otherButton.onClick.AddListener(ChangeNavigationToOther);
        }
        ChangeNavigationToGameplay();
    }

    private void ChangeNavigationToGameplay() {
        otherGroup.SetActive(false);
        videoGroup.SetActive(false);
        gameplayGroup.SetActive(true);
        foreach (OptionsSelecter upButton in upButtons) {
            gameplayNavigation = upButton.GetComponent<Button>().navigation;
            gameplayNavigation.mode = Navigation.Mode.Explicit;
            gameplayNavigation.selectOnDown = upSnapButtonGameplay;
            upButton.GetComponent<Button>().navigation = gameplayNavigation;
        }
        foreach (ButtonsManagerOptions bottomButton in bottomButtons) {
            gameplayNavigation = bottomButton.GetComponent<Button>().navigation;
            gameplayNavigation.mode = Navigation.Mode.Explicit;
            gameplayNavigation.selectOnUp = bottomSnapButtonGameplay;
            bottomButton.GetComponent<Button>().navigation = gameplayNavigation;
        }
    }

    private void ChangeNavigationToVideo() {
        otherGroup.SetActive(false);
        gameplayGroup.SetActive(false);
        videoGroup.SetActive(true);
        foreach (OptionsSelecter upButton in upButtons) {
            videoNavigation = upButton.GetComponent<Button>().navigation;
            videoNavigation.mode = Navigation.Mode.Explicit;
            videoNavigation.selectOnDown = upSnapButtonVideo;
            upButton.GetComponent<Button>().navigation = videoNavigation;
        }
        foreach (ButtonsManagerOptions bottomButton in bottomButtons) {
            videoNavigation = bottomButton.GetComponent<Button>().navigation;
            videoNavigation.mode = Navigation.Mode.Explicit;
            videoNavigation.selectOnUp = bottomSnapButtonVideo;
            bottomButton.GetComponent<Button>().navigation = videoNavigation;
        }
    }

    private void ChangeNavigationToOther() {
        gameplayGroup.SetActive(false);
        videoGroup.SetActive(false);
        otherGroup.SetActive(true);
        foreach (OptionsSelecter upButton in upButtons) {
            otherNavigation = upButton.GetComponent<Button>().navigation;
            otherNavigation.mode = Navigation.Mode.Automatic;
            upButton.GetComponent<Button>().navigation = otherNavigation;
        }
        foreach (ButtonsManagerOptions bottomButton in bottomButtons) {
            otherNavigation = bottomButton.GetComponent<Button>().navigation;
            otherNavigation.mode = Navigation.Mode.Automatic;
            bottomButton.GetComponent<Button>().navigation = otherNavigation;
        }
    }
}
