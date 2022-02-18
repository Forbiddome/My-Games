using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Limites;
    public Transform TransformLimites;
    public void RestartGame()
    {
        Pontuation.pontos = 0;
        SceneManager.LoadScene("Jogo");
        
    }
    private void Start()
    {
        Pontuation.pontos = 0;
        Time.timeScale = 1;
    }
}
