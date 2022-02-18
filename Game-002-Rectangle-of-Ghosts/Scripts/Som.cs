using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 10f)
            DestroyImmediate(this.gameObject,true);
        else
            timer+=Time.deltaTime;
    }
}
