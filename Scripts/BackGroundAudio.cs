using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudio : MonoBehaviour
{
    public AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        if (Pontuation.pontos < 15)
        {
            Audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Pontuation.pontos >= 15)
        {
            Audio.Stop();
        }
    }
}
