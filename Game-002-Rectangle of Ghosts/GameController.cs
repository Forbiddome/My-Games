using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Ghost;
    public float MaxTime;
    public float Timer;
    public int Pontuation;
    public Text PontuationText;
    public Vector3 PosicaoSquare;
    public float X, Y;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Pontuation = 0;
        PontuationText.text = Pontuation.ToString();
        MaxTime = 1f;
        Timer = 0f;
        PosicaoSquare = FindObjectOfType<Realocator>().transform.position;
        //O tyoe aqui se refere ao Tipo do Objeto = qual o Nome da Classe do Objeto no caso de RealocaCenario é BackgroundRealocate
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            SceneManager.LoadScene("Menu");

    }

    private void FixedUpdate()
    {
        PosicaoSquare = FindObjectOfType<Realocator>().transform.position;
        var randomizatorX = (int)Random.Range(0f, 1.9999f);
        var randomizatorY = (int)Random.Range(0f, 3.9999f);
        if (Timer > MaxTime)
        {
            switch (randomizatorX)
            {
                case 0:
                    X = 10f;
                    break;
                case 1:
                    X = -10f;
                    break;
                default:
                    break;
            }
            switch (randomizatorY)
            {
                case 0:
                    Y = .4f;
                    break;
                case 1:
                    Y = 1.4f;
                    break;
                case 2:
                    Y = -1.4f;
                    break;
                case 3:
                    Y = -.4f;
                    break;
                default:
                    break;
            }
            Instantiate(Ghost, new Vector3(PosicaoSquare.x + X, PosicaoSquare.y + Y, transform.position.z), Quaternion.identity);
            Timer = 0f;
        }
        Timer += Time.deltaTime;
    }
}
