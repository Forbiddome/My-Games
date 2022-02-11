using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianglesBUG : MonoBehaviour
{
    public float Speed;
    public float z;
    public Pontuation Pontuacao;
    public GameObject SoundTriangle;
    public GameObject SoundParabens;
    // Start is called before the first frame update
    void Start()
    {
        Pontuacao = FindObjectOfType<Pontuation>();
        Speed = -3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        z = z - Time.deltaTime * 200;
        transform.rotation = Quaternion.Euler(0,0,z);
    }
    public void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            Pontuation.pontos++;
            Pontuacao.Score++;
            Pontuacao.scoretext.text = Pontuacao.Score.ToString();
            Instantiate(SoundTriangle,new Vector3(outro.transform.position.x, outro.transform.position.y, outro.transform.position.z), Quaternion.identity);
            
            if (Pontuation.pontos == 15)
            Instantiate(SoundParabens, new Vector3(outro.transform.position.x, outro.transform.position.y, outro.transform.position.z), Quaternion.identity);
            
            Destroy(this.gameObject);
        }
    }
}
