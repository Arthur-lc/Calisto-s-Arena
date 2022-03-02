using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float speed = .5f;



    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // folow player
        Vector2 moveDir = player.transform.position - transform.position;
        moveDir = moveDir.normalized;
        rb.velocity = moveDir * speed;
    }
}
