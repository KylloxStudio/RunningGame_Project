using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;

    public float jumpPower;
    public bool isJumping;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            isGameOver = true;
        }
    }
}
