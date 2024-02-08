using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bomb;
    public GameObject fruit;

    public float spawnRate = 1f;
    public float bombChance = 20f;

    public List<Wave> waves = new List<Wave>();

    async void Start()
    {
        foreach (var wave in waves)
        {
            foreach (var item in wave.items)
            {
                // Rand Checks

                if (item.isRandomBomb)
                {
                    item.isBomb = Random.Range(0, 100) > bombChance ? true : false;
                    print(item.isBomb);
                }

                if (item.isRandomPos)
                {
                    var randomPosX = Random.Range(Camera.main.ViewportToWorldPoint(Vector3.zero).x + 1, Camera.main.ViewportToWorldPoint(Vector3.one).x) - 1;
                    item.x = randomPosX;
                }

                if (item.isRandomVelocity)
                {
                    float yVelocity = Random.Range(8f, 12f);
                    float xVelocity;
                    if (item.x >= 0)
                    {
                        xVelocity = Random.Range(-5f, 0f);
                    }
                    else
                    {
                        xVelocity = Random.Range(0f, 5f);
                    }
                    item.velocity = new Vector2(xVelocity, yVelocity);
                }

                for (int i = 0; i < 1; i++)
                {
                    await new WaitForSeconds(item.delay);
                    var prefab = item.isBomb ? bomb : fruit;
                    var go = Instantiate(prefab);

                    go.transform.position = new Vector3(item.x, -5, 0);

                    Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
                    rb.velocity = item.velocity;
                    rb.angularVelocity = Random.Range(-200, 200);

                }
            }
            
            await new WaitForSeconds(2f);
        }
    }
}
