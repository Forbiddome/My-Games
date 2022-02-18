using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SomTriangulos : MonoBehaviour
{
    public float tempo = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("Criou-se som");
    }

    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        if (tempo <= Time.deltaTime)
        {
            Console.WriteLine("Destruiu som");
            Destroy(this.gameObject);
        }
    }
}
