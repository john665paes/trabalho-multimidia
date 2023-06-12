using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{   
    Animator animator;

    public float intervaloAtaque;
    private float proximoAtaque;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {   
        // Time.time verifica o tempo do jogo
         if(Input.GetButtonDown("Fire2") && Time.time > proximoAtaque)
         {
            Atacando();
         }
    }
    void Atacando()
    {
        animator.SetTrigger("attack");
        proximoAtaque = Time.time + intervaloAtaque;
    }
}
