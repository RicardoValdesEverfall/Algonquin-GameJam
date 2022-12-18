using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isBoxPickedUp = false;
    [SerializeField] private int coins = 0;

    public void PickUpBox()
    {
        isBoxPickedUp = true;
    }

    public void PickUpCoin()
    {
        coins++;
    }
}
