using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [System.NonSerialized] public GameObject player;
    [System.NonSerialized] public Rigidbody2D rb;
    public float speed = .5f;
    public LayerMask playerMask;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update() {}

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

    public void Follow(Transform target) {
        Vector3 moveDir = target.position - transform.position;
        Vector3 distortion = new Vector3(Random.Range(-.0075f, .0075f), Random.Range(-.0075f, .0075f), 0);
        moveDir = moveDir.normalized;
        rb.MovePosition(transform.position + distortion + moveDir * Time.fixedDeltaTime * speed);
    }

    /*public void GetAway(Transform target) {
        Vector2 moveDir = transform.position - target.position;
        moveDir = moveDir.normalized;
        rb.velocity = moveDir * speed;
    }*/
}
