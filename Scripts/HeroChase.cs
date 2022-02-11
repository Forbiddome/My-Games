using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroChase : MonoBehaviour
{
    public float EnemyVelocity;
    private Transform HeroPosition;
    private SpriteRenderer Sr;
    // Start is called before the first frame update

    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        HeroPosition = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyVelocity = .5f;

    }
    // Update is called once per frame
    void Update()
    {
        if(HeroPosition.gameObject !=null)
            transform.position = Vector2.MoveTowards(transform.position, HeroPosition.position, EnemyVelocity * Time.deltaTime);
        if (HeroPosition.position.x > this.gameObject.transform.position.x)
        {
            Sr.flipX = false;
        }
        else if(HeroPosition.position.x < this.gameObject.transform.position.x)
        {
            Sr.flipX = true;
        }
    }
}
