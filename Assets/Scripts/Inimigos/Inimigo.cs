using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour{

    private GameObject player; 
    public float velocidade = 2f;
    private bool moverInimigo = false;
    private Animator animator;
    public int dano;

    void Awake(){
        animator = GetComponent<Animator>();
    }
    void Start(){
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update(){
        if (moverInimigo){
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidade*Time.deltaTime);
            animator.SetBool("run", true);
        }else{
            animator.SetBool("run", false);
        }

        // MOVIMENTAÇÃO PARA OS LADOS
        if (transform.position.x < player.transform.position.x) {
            transform.localScale = new Vector3(2, 2, 1); //Direita
        } else 
        {
            transform.localScale = new Vector3(-2, 2, 1); //Esquerda
        }

    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") moverInimigo = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") moverInimigo = false;
    }
    
}