using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : Enemy
{
    public override void Update()
    {
        base.Update();

        Vector2 moveDir = player.transform.position - transform.position;
        moveDir = moveDir.normalized;
        rb.velocity = moveDir * speed;
    }
}
