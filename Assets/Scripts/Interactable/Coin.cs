using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameManager GM;

    private bool once = true;

    public float amplitude = 0.5f; //how much the coin goes up and down
    public float frequency = 1f; //how much time it takes to complete a loop
    public float rotationSpeed = 30f;
    
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public AudioClip coinPickup;

    public ParticleSystem ps;

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
        if (other.CompareTag("Player") && once)
        {
            once = false;

            GM.PickUpCoin();
            ps.Play();
            AudioSource.PlayClipAtPoint(coinPickup, transform.position, 1);
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Invoke(nameof(DestroyObj), ps.main.duration);
        }
    }

    void Hover()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency)* amplitude;
        transform.position = tempPos;
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
