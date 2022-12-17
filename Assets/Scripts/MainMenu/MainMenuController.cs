using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        var Root = GetComponent<UIDocument>().rootVisualElement;

        startButton = Root.Q<Button>("start-button");
        quitButton = Root.Q<Button>("quit-button");

        startButton.clicked += StartButtonPressed;
        quitButton.clicked += QuitButtonPressed;
    }

    void StartButtonPressed()
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
