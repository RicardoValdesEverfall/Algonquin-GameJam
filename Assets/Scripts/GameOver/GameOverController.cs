using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button mainMenuButton;
    public Button restartButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        var Root = GetComponent<UIDocument>().rootVisualElement;

        mainMenuButton = Root.Q<Button>("main-menu-button");
        restartButton = Root.Q<Button>("restart-button");
        quitButton = Root.Q<Button>("quit-button");

        mainMenuButton.clicked += MainMenuButtonPressed;
        restartButton.clicked += RestartButtonPressed;
        quitButton.clicked += QuitButtonPressed;
    }
    void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }

    void RestartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    void QuitButtonPressed()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
