using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

    public GameObject player;
    public float velocidade = 15f;

    public bool podeMover = true;
    private Animator animator;
    void Awake() {
        animator = GetComponent<Animator>();
    }
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update(){    
        Debug.Log("AA");
        Debug.Log(podeMover);

        animator.SetBool("podeMover", podeMover);
        if (podeMover) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidade * Time.deltaTime);
            
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") podeMover = false;
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") podeMover = true;
    }

}