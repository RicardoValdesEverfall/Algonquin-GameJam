using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum Timeline { blue, red, green };
    [SerializeField] private Timeline currentTimeline = Timeline.blue;

    [SerializeField] private bool isBoxPickedUp = false;

    [SerializeField] private int coins = 0;
    [SerializeField] private Canvas coinCounter;
    [SerializeField] private TextMeshProUGUI wallet;
    [SerializeField] private TextMeshProUGUI counter;

    [SerializeField] private UIDocument gameOverScreen;

    private static GameManager _instance;
    private static GameManager Instance {get {return _instance;}}

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void PickUpBox()
    {
        isBoxPickedUp = true;
    }

    public bool getBoxStatus()
    {
        return isBoxPickedUp;
    }

    public void PickUpCoin()
    {
        coins++;
        ShowCoinCounter();
        Invoke("HideCoinCounter", 5);
    }

    public void ShowCoinCounter()
    {
        if (!coinCounter.enabled)
        {
            coinCounter.enabled = true;
        }
        wallet.text = coins.ToString();
    }
    
    public void HideCoinCounter()
    {
        if(coinCounter.enabled)
        {
            coinCounter.enabled = false;
        }
    }

    public void SetTimeline(Timeline timeline)
    {
        currentTimeline = timeline;
    }

    public void Obelisk()
    {
        // TODO: Open a radial menu to choose between timelines
        // Radial menu should utilize the SetTimeline() method
    }

    public void gameOver()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        // TODO: Disable keyboard input / player movement

        gameOverScreen.enabled = true;
    }
}
