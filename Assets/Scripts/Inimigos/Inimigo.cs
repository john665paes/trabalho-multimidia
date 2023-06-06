using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehavior {

    private GameObject player;
    public float velocidade = 2f;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");

    }
     void update(){
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidade*Time.deltatime);
    }

}