using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuation : MonoBehaviour
{
    public int Score;
    public Text scoretext;
    public static int pontos;
    // Start is called before the first frame update
    void start()
    {
        pontos = 0;

    }
}
