using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Dash")]
public class DashAbility : Ability
{
    public float dashVelocity;
    
    public override void Activate(GameObject parent) {
        base.Activate(parent);

        MovementController movement = parent.GetComponent<MovementController>();
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

        rb.velocity = movement.movementInput.normalized * dashVelocity;
    }
}
