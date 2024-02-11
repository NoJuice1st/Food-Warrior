using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;

    public int comboCount;
    public float comboTimeLeft;
    public AudioClip comboSound;

    private void Start()
    {
        Application.targetFrameRate = 60;
        if(Application.isEditor) Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        rb.MovePosition(pos);

        if (comboTimeLeft > 0) comboTimeLeft -= Time.deltaTime;
        else
        {
            if (comboCount > 2)
            {
                AudioSystem.Play(comboSound);
            }
            comboCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var fruit = collision.gameObject.GetComponent<Fruit>();
        fruit.Slice();
        
        if (!collision.CompareTag("Bomb"))
        {
            GameManager.AddScore(1);
            comboTimeLeft = 0.2f;
            comboCount++;
        }
        else
        {
            //Bomb
            GameManager.health = 0;

            if (GameManager.health == 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
