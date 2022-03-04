using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float speed = .5f;
    [SerializeField] private LayerMask playerMask;

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

    public void Spawn(float radius) {
        transform.position = RandomPolar(radius);
        while (Physics2D.OverlapCircle(transform.position, 1f, playerMask))
        {
            transform.position = RandomPolar(radius);
        }
    }

    private Vector2 RandomPolar (float radius) {
        /*
            retorna um vetor com um ponto aleatorio dentro de um criculo
            de raio radius, utilizando coordenadas polares.
            https://www.youtube.com/watch?v=4y_nmpv-9lI
        */
        float theta = Random.Range(0f,2f * 3.14f);
        float r = Random.Range(0f, radius);
        return new Vector2(r * Mathf.Cos(theta), r * Mathf.Sin(theta));
    }
}
