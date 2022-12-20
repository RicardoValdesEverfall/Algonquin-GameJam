using UnityEngine;

public class Obelisk : MonoBehaviour
{
    [SerializeField] private GameManager GM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GM.getBoxStatus())
        {
            GM.Obelisk();
        }
    }
}
