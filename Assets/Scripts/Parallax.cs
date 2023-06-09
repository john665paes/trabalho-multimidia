using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{   
    private float comprimento_back;
    private float posicao_start, restart_posicao;
    public GameObject camera;
    // variavel para atribuir a velocidade de cada objeto
    public float velocidadeParallax;
    
    void Start()
    {
        posicao_start = transform.position.x;
        //pegando o comprimento dos sprites no eixo x
        comprimento_back =  GetComponent<SpriteRenderer>().bounds.size.x;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        Debug.Log(camera);
        Debug.Break();
    }

    void Update()
    {   
        //para reposicionar antes de acabar o background
        float restart_posicao = camera.transform.position.x * (1 - velocidadeParallax);
        float Distancia = camera.transform.position.x * velocidadeParallax;
        //movimentando a camera, apenas no eixo x
        transform.position = new Vector3(posicao_start + Distancia, transform.position.y, transform.position.z);

        if (restart_posicao > posicao_start + comprimento_back)
        {
            posicao_start += comprimento_back;
        } 
        else if(restart_posicao < posicao_start - comprimento_back)
        {
            posicao_start -= comprimento_back;
        }

    }
}
