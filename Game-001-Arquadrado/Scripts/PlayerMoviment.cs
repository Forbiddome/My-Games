using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D Rb;
    public float JumpSpeed;
    public float Speed;
    public SpriteRenderer Sr;
    private float Horizontal;
    public GameObject GameOver;


    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        Speed = 6f;
        JumpSpeed = 300f;  
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        Jump();
    }

    public void Moviment()
    {
        Horizontal = Input.GetAxis("Horizontal");
        if (Horizontal != 0)
        {
            Rb.velocity = new Vector2(Horizontal * Speed, Rb.velocity.y);
            if (Horizontal < 0)
            {
                Sr.flipX = true;
            }
            else
            {
                Sr.flipX = false;
            }
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Rb.velocity = Vector2.up * JumpSpeed * Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D Colisor)
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}