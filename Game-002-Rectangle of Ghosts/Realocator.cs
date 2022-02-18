using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realocator : MonoBehaviour
{
    private float Length;
    private float StartPos;
    private Transform Cam;
    private float parallaxEffect;

    void Start()
    {
        parallaxEffect = 0;
        StartPos = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
        Cam = Camera.main.transform;
    }
    void Update()
    {
        float Repos = Cam.transform.position.x* (1-parallaxEffect);
        float Distance = Cam.transform.position.x * parallaxEffect;
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
