using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrParaJogo : MonoBehaviour
{
    // Start is called before the first frame update
    public void IrParaOJogo()
    {
        SceneManager.LoadScene("Jogo");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
