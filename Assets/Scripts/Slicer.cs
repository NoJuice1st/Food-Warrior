using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;
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
        //transform.position = pos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
