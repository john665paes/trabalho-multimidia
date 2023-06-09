using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour{

    private GameObject player;
    public float velocidade = 2f;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");

    }
     void Update(){
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidade*Time.deltaTime);
    }

}