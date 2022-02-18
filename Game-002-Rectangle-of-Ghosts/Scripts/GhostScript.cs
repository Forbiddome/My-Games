using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    private Vector2 input;
    private bool isMoving;
    private SpriteRenderer Sr;
    public GameObject SoundDano;
    public float moveSpeed;
    public float contador, ContadorMax;
    private GameController Pontuar;
    private Vector3 DirectionController;
    //Ou Transform em vez de Vector3
    private Player TiraVida;
    private bool ChecaDestroy;
    private float timeDestroy;
    public LayerMask BalaLayer, PlayerLayer;
    public int sorteio;
    public GameObject BoostLife, BoostShoot, BoostSpeed;
    public Player Protagonist;
    public Tiro Balas;

    void Start()
    {
        ContadorMax = 1f;
        contador = 0;
        moveSpeed = 10000f;
        timeDestroy = 0f;

        Protagonist = FindObjectOfType<Player>();
        Pontuar = FindObjectOfType<GameController>();
        DirectionController = FindObjectOfType<GameController>().transform.position;
        TiraVida = FindObjectOfType<Player>();
        Sr = GetComponent<SpriteRenderer>();
        ChecaDestroy = false;

        sorteio = (int)Random.Range(0, 6);

        if (transform.position.x > DirectionController.x)
        {
            input.x = -1f;
            Sr.flipX = false;
        }
        else
        {
            input.x = 1f;
            Sr.flipX = true;
        }
        input.y = 0f;
    }
    void Update()
    {
        sorteio = (int)Random.Range(0, 6);
        

        if (timeDestroy >= 10000f)
            ChecaDestroy = true;
        else
        {
            timeDestroy++;
        }

        HittingPlayer();

        if (this.gameObject != null)
            if (ChecaDestroy)
            {
                Destroy(this.gameObject, 0);
            }
    }
    void FixedUpdate()
    {
        if (!isMoving)
        {

            var targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;

            if (contador > ContadorMax)
            {
                StartCoroutine(Move(targetPos));
                contador = 0f;
            }
        }
        contador += Time.deltaTime * 1.5f;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Sortear(sorteio);
            Destroy(this.gameObject,0);
        }
    }

    private void HittingPlayer()
    {
        if (Physics2D.OverlapCircle(transform.position, .3f, PlayerLayer) != null)
        {
            Sortear(sorteio);
            TiraVida.Life--;
            Instantiate(SoundDano, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            ChecaDestroy = true;
        }
    }

    public void Sortear(int sorteio)
    {
        switch (sorteio)
        {
            case 0:
                if (Balas.BoostSpeedTiro < 12) Instantiate(BoostShoot, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                break;
            case 1:
                if (Protagonist.boostSpeed < 6) Instantiate(BoostSpeed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                break;
            case 2:
                if (Protagonist.Life < 5) Instantiate(BoostLife, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                break;
        }
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
