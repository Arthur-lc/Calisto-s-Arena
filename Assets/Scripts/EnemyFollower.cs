using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : Enemy
{
    public bool following;
    public bool lookAtTarget;
    public float stopAtDistance;
    public float movementNoise;
    

    private void FixedUpdate() {
        if (lookAtTarget)
            LookAt(player.transform);

        if (following)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > stopAtDistance)
                base.Follow(player.transform, movementNoise);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopAtDistance);
    }

}
