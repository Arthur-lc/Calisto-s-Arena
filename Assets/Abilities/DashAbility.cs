using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[CreateAssetMenu(menuName = "Abilities/Dash")]
public class DashAbility : Ability
{
    public float dashVelocity;
    public bool invinerability = false;
    
    public override void Activate(AbilityHolder holder) {
        base.Activate(holder);
        holder.cooldownModifier = holder.abilityLevel;

        MovementController movement = holder.GetComponent<MovementController>();
        Rigidbody2D rb = holder.GetComponent<Rigidbody2D>();

        rb.velocity = movement.movementInput.normalized * dashVelocity;
        if (invinerability)
        {
            Invunerable(cooldownTime, holder.GetComponent<SpriteRenderer>());
        }
    }

    private async void Invunerable(float waitTime, SpriteRenderer player) {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        player.enabled = false;
        await Task.Delay(400);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
        player.enabled = true;
    }
}
