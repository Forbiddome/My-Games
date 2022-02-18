using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    private Vector2 input;
    private bool isMoving;
    private SpriteRenderer Sr;
    private SpriteRenderer DirectionPlayer;
    public GameObject SoundTiro;
    private GameController Pontuar;
    public float moveSpeed;
    public float contador;
    private float timeDuration;
    private bool ChecaDestroy;
    public LayerMask WallLayer;
    public LayerMask InimigoLayer;
    public float MaxTimerVel, TimerVel;
    public float BoostSpeedTiro;
    //Ou Transform em vez de Vector3

    void Start()
    {
        BoostSpeedTiro = 1f;
        MaxTimerVel = 1f;
        TimerVel = 0f;
        timeDuration = 10;
        contador = 0;
        moveSpeed = 10000f;

        ChecaDestroy = false;
        Pontuar = FindObjectOfType<GameController>();
        Sr = GetComponent<SpriteRenderer>();
        Instantiate(SoundTiro, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //Destroy e tempo só pode ser usado com um objeto falando sobre outro e não o proprio objeto  se referenciando para se autodestruir
        // a unity buga e diz q devemos usar ou Destroy(this.gameObject) ou DestroyImmediate(objectname,trueorfalse);

        DirectionPlayer = FindObjectOfType<Player>().Sr;
        if (DirectionPlayer.flipX)
        {
            input.x = -1f;
            Sr.flipX = true;
        }
        else
        {
            input.x = 1f;
            Sr.flipX = false;
        }
        input.y = 0f;
    }
    void Update()
    {
        if (!isMoving)
        {

            var targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;

            if (TimerVel >= MaxTimerVel)
            {
                StartCoroutine(Move(targetPos));
                TimerVel = 0f;
            }
        }
        //Shoot movement speed with Boost
        TimerVel += Time.deltaTime * BoostSpeedTiro*2;

        if (timeDuration <= 0) ChecaDestroy = true;
        else timeDuration -= Time.deltaTime;

        //HittingInimigo();
        HittingWall();

        if (this.gameObject != null)
            if (ChecaDestroy) Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {
            Pontuar.Pontuation++;
            Pontuar.PontuationText.text = Pontuar.Pontuation.ToString();
            Destroy(this.gameObject, 0);
        }
    }

    private void HittingWall()
    {
        if (Physics2D.OverlapCircle(transform.position, .01f, WallLayer) != null)
        {
            ChecaDestroy = true;
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
