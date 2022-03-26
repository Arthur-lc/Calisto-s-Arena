using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Dash")]
public class DashAbility : Ability
{
    public float dashVelocity;
    
    public override void Activate(AbilityHolder holder) {
        base.Activate(holder);
        holder.cooldownModifier = holder.abilityLevel;

        MovementController movement = holder.GetComponent<MovementController>();
        Rigidbody2D rb = holder.GetComponent<Rigidbody2D>();

        rb.velocity = movement.movementInput.normalized * dashVelocity;
    }
}
