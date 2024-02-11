using UnityEngine;
using UnityEngine.SceneManagement;


public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explodeParticles;

    public GameObject leftSide;
    public GameObject rightSide;

    public Color juiceColor;

    public AudioClip missSound;
    public AudioClip spawnSound;
    public AudioClip sliceSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioSystem.Play(spawnSound);
    }

    private void Update()
    {
        if (transform.position.y < -6)
        {
            Miss();
        }
    }

    void Miss()
    {
        if (!CompareTag("Bomb"))
        {
            AudioSystem.Play(missSound);

            GameManager.health--;

            if (GameManager.health == 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explodeParticles);
        particles.transform.position = transform.position;

        Destroy(gameObject);
        if (!CompareTag("Bomb")) Split(particles);
        AudioSystem.Play(sliceSound);
    }

    public void Split(GameObject particles)
    {
        // sperate children
        transform.DetachChildren();

        var leftRb = leftSide.AddComponent<Rigidbody2D>();
        var rightRb = rightSide.AddComponent<Rigidbody2D>();

        leftRb.velocity = rb.velocity + new Vector2(-2, 0);
        rightRb.velocity = rb.velocity + new Vector2(2, 0);

        particles.GetComponent<ParticleSystem>().startColor = juiceColor;
        particles.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = juiceColor;

        Invoke("RemoveLeftovers", 10f);
    }

    void RemoveLeftovers()
    {
        Destroy(leftSide);
        Destroy(rightSide);
    }
}
