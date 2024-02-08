using UnityEngine;
using System.Collections.Generic;
using OneLine;
using System;

[Serializable]
public class SpawnItemData
{
    public float delay;
    public bool isBomb;
    public float x;
    public Vector2 velocity = new Vector2(0, 10f);

    public bool isRandomPos;
    public float bombChance;
    public bool isRandomVelocity;
}

[Serializable] // Makes them visable in the inspector
public class Wave
{
    [OneLineWithHeader]public List<SpawnItemData> items;
}
