using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    public float velocidade;
    private Transform player;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        var destino = player.position;
        destino.z = transform.position.z;
        transform.position = destino;
    }
}
