using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, Random.Range(10, 15));
        rb.angularVelocity = Random.Range(-100, 100);
    }

    private void Update()
    {
        if (transform.position.y < -6)
        {
            print("oops");
            Destroy(gameObject);
        }
    }
}
