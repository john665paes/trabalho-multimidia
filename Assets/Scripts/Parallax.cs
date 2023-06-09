using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{   

    private float comprimento_back;
    private float posicao_start;
    private Transform camera;

    // variavel para atribuir a velocidade de cada objeto
    public float efeitoParallax;
    // Start is called before the first frame update
    void Start()
    {
        posicao_start = transform.position.x;
        //pegando o comprimento dos sprites no eixo x
        comprimento_back =  GetComponent<SpriteRenderer>().bounds.size.x;
        camera = camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float Distancia = camera.transform.position.x * efeitoParallax;
        //movimentando a camera
        transform.position = new Vector3(posicao_start + Distancia, transform.position.y, transform.position.z);

    }
}
