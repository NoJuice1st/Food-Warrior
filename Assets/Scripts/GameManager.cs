using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int health;
    public TMP_Text healthText;
    public TMP_Text scoreText;

    private void Awake()
    {
        score = 0;
        health = 3;
    }

    public static void AddScore(int scoreAdd)
    {
        score += scoreAdd;
    }

    private void Update()
    {
        healthText.text = "Health:" + health.ToString();
        scoreText.text = "Score:" + score.ToString();
    }
}
