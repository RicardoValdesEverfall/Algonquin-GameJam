using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameManager GM;

    public float amplitude = 0.5f; //how much the coin goes up and down
    public float frequency = 1f; //how much time it takes to complete a loop
    
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Hover();
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GM.PickUpCoin();
            Destroy(gameObject);
        }
    }

    void Hover()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency)* amplitude;
        transform.position = tempPos;
    }
}
