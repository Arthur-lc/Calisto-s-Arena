using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillable : Killable
{
    public override void TakeDamage(float damageTaken)
    {
        base.TakeDamage(damageTaken);
        Events.onHealthChange.Invoke(hp);
    }
    public override void Die()
    {
        Time.timeScale = 0;
    }
}
