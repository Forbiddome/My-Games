using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioParabens : MonoBehaviour
{

    void Update()
    {
  
        if (Pontuation.pontos < 15)
        {
            Destroy(this.gameObject);
        }
    }
}
