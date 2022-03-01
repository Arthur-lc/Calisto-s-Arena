using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float normalAcceleration = 30f;
    [HideInInspector] public float acceleration;
    [HideInInspector] public Vector2 movementInput;
    public Transform mouseDir;
    public GameObject pointingArrow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        acceleration = normalAcceleration;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir.up = (mousePos - (Vector2)transform.position).normalized;
    }

    private void FixedUpdate() {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementInput = movementInput.normalized;
        rb.velocity += movementInput * acceleration * Time.fixedDeltaTime;
    }
}
