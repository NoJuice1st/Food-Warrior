using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bomb;
    public GameObject fruit;
    public float spawnRate = 1f;
    public float bombChance = 20f;

    void Spawn()
    {
        var prefab = Random.Range(0, 100) < 100 - bombChance ? fruit : bomb;

        var posX = Random.Range(Camera.main.ViewportToWorldPoint(Vector3.zero).x + 1, Camera.main.ViewportToWorldPoint(Vector3.one).x) - 1;
        Vector3 pos = new Vector3(posX, -6, 0);
        Instantiate(prefab, pos, Quaternion.identity);
    }

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnRate);
    }
}
