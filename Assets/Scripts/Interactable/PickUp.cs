using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameManager GM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GM.isBoxPickedUp = true;
        }
    }
}
