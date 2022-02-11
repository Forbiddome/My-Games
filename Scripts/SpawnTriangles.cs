using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriangles : MonoBehaviour
{
    public GameObject Triangles;
    public float height;
    public float MaxTime;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        MaxTime = 1f;
        Timer = 0f;
        //INSTANCIA LOGO NO INICIO
        GameObject newTriangles = Instantiate(Triangles);
        newTriangles.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        TrianglesSpawner();
    }

    void TrianglesSpawner()
    {
        if (Timer > MaxTime)
        {
            GameObject newTriangles = Instantiate(Triangles);
            newTriangles.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newTriangles, 40f);
            Timer = 0f;
        }
        Timer += Time.deltaTime;
    }
}