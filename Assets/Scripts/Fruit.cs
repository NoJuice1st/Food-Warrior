using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 10);
        rb.angularVelocity = 25;
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
