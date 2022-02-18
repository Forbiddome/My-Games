using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTiro : Boost
{
    public Tiro AugmentTiro;
    public GameObject BoostSound;
    // Start is called before the first frame update
    void Start()
    {
        Starter();
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
            AugmentTiro.BoostSpeedTiro++;
            Instantiate(BoostSound, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            ChecaDestroy = true;
        }
    }
}
