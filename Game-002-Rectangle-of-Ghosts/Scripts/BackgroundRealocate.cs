using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRealocate : MonoBehaviour
{
    private float Length;
    private float StartPos;
    private Transform Cam;
    public float ParallaxEffect = 0;

    void Start()
    {
        StartPos = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
        Cam = Camera.main.transform;
    }
    void Update()
    {
        float Repos = Cam.transform.position.x * (1 - ParallaxEffect);
        float Distance = Cam.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);


        if (Repos > StartPos + Length)
        {
            StartPos += Length;
        }
        else if (Repos < StartPos - Length)
        {
            StartPos -= Length;
        }
    }
}
