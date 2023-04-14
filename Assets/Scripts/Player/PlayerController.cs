using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float velocidade = 4f; // velociada padão inical
    public float forcaPulo = 100f;
    public Rigidbody2D rb;
    public LayerMask layerMask;
    private Animator animator;

    public bool noChao;
    // Start is called before the first frame update
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update(){
        
        //caso o collider seja != de nulo é porque colidou com algo do layer selecionando 
        noChao = Physics2D.Raycast(transform.position, Vector3.down, 3f, layerMask).collider != null;
        
        //mudar as animações
        animator.SetBool("run", Input.GetButton("Horizontal"));
        animator.SetBool("chao", noChao);
        
            //Para pular Jump é o botão de espaço / só pula se estiver no chão
        if (Input.GetButtonDown("Jump") && noChao) {
            animator.SetTrigger("jump");
            // aqui vai receber um força empurrando para cima
            rb.AddForce(Vector2.up * forcaPulo);            
        }
        //Horizontal - movimentação esquerda e direita
        if (Input.GetAxisRaw("Horizontal") > 0){
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.localScale = new Vector3(2, 2, 1);

        } else if (Input.GetAxisRaw("Horizontal") < 0){
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            //para virar a esquerda
            transform.localScale = new Vector3(-2, 2, 1);
        }
    }
}