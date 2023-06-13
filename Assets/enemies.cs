using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{   
    public Animator animacao;
    public SpriteRenderer sprite;

    private int life = 5;
    public float velocidade = 4f;
        
    public Transform[] pointsToMove; // vetor para armazenar as duas posições
    public int startingPoint;

    public BoxCollider2D colliderAtaque;
    public BoxCollider2D colliderCheckAtaque;   
    
    void Start()
    {
        animacao = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        transform.position = pointsToMove[startingPoint].transform.position;
    }
    
    void Update()
    {
        // inverter a posição, colisor e Sprite
        if (startingPoint == 0)
        {
            sprite.flipX = true;
            colliderAtaque.offset = new Vector2(-2, 2);
            colliderCheckAtaque.offset = new Vector2(-2, 2);
        }
        else
        {
            sprite.flipX = false;
            colliderAtaque.offset = new Vector2(2, 2);
            colliderCheckAtaque.offset = new Vector2(2, 2);
        }

        if (life == 0)
        {
            EnemyMorre();
        }
    }
    private void FixedUpdate()
    {
        mover();
    }
    private void mover()
    { //  movendo do x ao y

        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[startingPoint].tranform.position, velocidade * Time.deltaTime);
    
        if (enimiesCheckAttack.checkAttack == true)
        {
            // executada quando o personagem cegar perto
            StartCoroutine("Attack");
        }
        // movimentação do inimigo de um lado para o outro
        if (transform.position == pointsToMove[startingPoint].transform.position)
        {
            startingPoint += 1;
        } 

        if (startingPoint == pointsToMove.Length)
        {
            startingPoint = 0;
        }
        // mudando a movimentação da animação
        if (velocidade != 0)
        {
            animacao.SetBool("run", true);
        }
        else
        {
            animacao.SetBool("run", false);
        }
    }
    private void EnemyMorre()
    {
        life = 0;
        animacao.SetTrigger("dead");
        velocidade = 0;
        Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
        Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
        Destroy(colliderAtaque);
        Destroy(colliderCheckAtaque);
        Destroy(this);
    }
    
    // a rotina de ataque citada acima
    IEnumerator Attack()
    {
        animacao.SetBool("atack", true);
        velocidade = 0;

        yield return new WaitForSeconds(0.85f);
        animacao.SetBool("atack", false);
        velocidade = 1;

        enimiesCheckAttack.checkAttack == false;        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack")
        {
            life -- ;
            if (life < 1)
            {
                StopCoroutine("Attack");
                EnemyMorre();
            }
        }
    }
}
