using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillable : Killable
{
    public override void TakeDamage(float damageTaken)
    {
        ImpulseManager.Instance.Shake(damageTaken / maxHp);
        hp -= damageTaken;

        if (hp <= 0)
        {
            Die();
        }
        else
        {
            audioSource.Play();
        }

        Events.onHealthChange.Invoke(hp);
    }

    public void Heal(float healAmount) {
        hp += healAmount;
        if (hp > maxHp)
            hp = maxHp;
        Events.onHealthChange.Invoke(hp);
    }

    public override void Die()
    {
        GameManager.Instance.UpdateGameState(GameState.GameOver);
    }
}
