using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruit;

    void SpawnFruit()
    {
        var posX = Random.Range(Camera.main.ViewportToWorldPoint(Vector3.zero).x + 1, Camera.main.ViewportToWorldPoint(Vector3.one).x) - 1;
        Vector3 pos = new Vector3(posX, -6, 0);
        Instantiate(fruit, pos, Quaternion.identity);
    }

    void Start()
    {
        InvokeRepeating("SpawnFruit", 2f, 1f);   
    }
}
