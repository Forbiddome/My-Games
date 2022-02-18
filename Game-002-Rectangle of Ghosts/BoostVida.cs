using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostVida : Boost
{
    public Player AugmentLife;
    public GameObject BoostSound;
    // Start is called before the first frame update
    void Start()
    {
        Starter();
        AugmentLife = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Updater();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            //Life Boost
            AugmentLife.Life++;
            Instantiate(BoostSound, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            ChecaDestroy = true;
        }
    }
}
