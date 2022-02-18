using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    protected float Timer;
    protected float MaxTimer;
    protected bool ChecaDestroy;

    protected void Starter()
    {
        MaxTimer = 10f;
        Timer = 0f;
    }

    protected void Updater()
    {
        if (Timer >= MaxTimer || ChecaDestroy)
        {
            if (this.gameObject != null)
                Destroy(this.gameObject, 0);
        }
        else
        {
            Timer += Time.deltaTime;
        }
    }
}
