using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isBoxPickedUp = false;
    [SerializeField] private int coins = 0;
    
    [SerializeField] private Canvas coinCounter;
    [SerializeField] private TextMeshProUGUI wallet;
    [SerializeField] private TextMeshProUGUI counter;

    public void PickUpBox()
    {
        isBoxPickedUp = true;
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
}
