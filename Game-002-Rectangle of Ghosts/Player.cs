using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 input;
    private bool isMoving;
    private Animator Anim;
    public SpriteRenderer Sr;
    public LayerMask LayerObstaculo;
    public float MaxTimerTiro;
    public float Timertiro;
    public GameObject Bala;
    public float boostSpeed;
    public float moveSpeed;
    public float contador;
    public int Life;
    public Text LifeText;
    public GameObject GameOver;
    public GameObject ImageObject;
    public GameObject Exit;
    public Tiro GetTiro;
    public float ExistentTiro;

    void Start()
    {
        ExistentTiro = 1f;
        Timertiro = 0f;
        Life = 2;
        boostSpeed = 1;
        contador = 0;
        moveSpeed = 10000f;
        MaxTimerTiro = 1f;

        LifeText.text = Life.ToString();
        Anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        LifeText.text = Life.ToString();
        Movement();
        Shoot();
        if(Life <= 0)
        {
            ImageObject.SetActive(true);
            GameOver.SetActive(true);
            Exit.SetActive(false);
            Time.timeScale = 0;
        }
        //Shoot speed of spawn time with Boost /2
        if (GetTiro.BoostSpeedTiro != 0)
        {
            ExistentTiro = GetTiro.BoostSpeedTiro;
        }
    }

    public void Shoot()
    {
        if (Timertiro > MaxTimerTiro && Input.GetKey(KeyCode.Space))
        {
            float Direcao;
            if (!Sr.flipX) Direcao = 1f;
            else Direcao = -1f;

            Instantiate(Bala, new Vector3(transform.position.x + Direcao, transform.position.y, transform.position.z), Quaternion.identity);
            Timertiro = 0f;
        }
        //Shoot speed of spawn time with Boost /2
        Timertiro += Time.deltaTime*ExistentTiro/2;
    }

    public void Movement()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0)
                input.y = 0;

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos) && contador <= 0)
                {
                    StartCoroutine(Move(targetPos));
                    contador = 1f;
                }

                Anim.SetBool("correndo", true);
                if (input.x > 0)
                {
                    Sr.flipX = false;
                }
                else if (input.x < 0)
                {
                    Sr.flipX = true;
                }
            }
            else
            {
                Anim.SetBool("correndo", false);
            }
        }
        if (contador > 0) contador -= Time.deltaTime * boostSpeed;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, .05f, LayerObstaculo) != null)
        {
            return false;
        }
        return true;
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
