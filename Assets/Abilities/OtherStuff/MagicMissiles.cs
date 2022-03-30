using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissiles : Projectile
{
    public float timeToStartFollowing;
    public float range;
    private Transform target;
    private Vector3 mousePos;

    private bool a = true;

    public LayerMask mask;

    public override void Start() {
        base.Start();
        /*mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;*/

        mousePos = GameObject.Find("CovergencePoint").transform.position;
    }
    
    void FixedUpdate()
    {
        
        if (timeToStartFollowing > 0)
        {
            timeToStartFollowing -= Time.deltaTime;
        }
        else
        {
            if (target == null)
            {
                if (a) 
                {
                    transform.up = mousePos - transform.position;
                    rb.velocity = (transform.rotation * Vector2.up) * speed;
                    a = false;
                }

                if (Physics2D.OverlapCircle(transform.position, range, mask))
                {
                    Collider2D[] possibleTargets = Physics2D.OverlapCircleAll(transform.position, range, mask);
                    Debug.Log(possibleTargets.Length);
                    target = GetClosestEnemy(possibleTargets).transform;
                    Debug.Log(target.name);
                }
            }
            else
            {
                Follow(target.position);
            }
        }
    }

    private void Follow(Vector3 target) {
        Debug.Log("target" + target);
        Vector3 moveDir = target - transform.position;
        moveDir = moveDir.normalized;
        rb.MovePosition(transform.position + moveDir * Time.deltaTime * speed);
        transform.up = target - transform.position;
    }

    private Collider2D GetClosestEnemy(Collider2D[] enemies) {
        Collider2D bestTarget = enemies[0];
        float bestDistance = -1;
        foreach(Collider2D possibleTarget in enemies)
        {
            float distance = Vector2.Distance(transform.position, possibleTarget.transform.position);
            if (distance < bestDistance || bestDistance == -1)
            {
                bestDistance = distance;
                bestTarget = possibleTarget;
            }
        }
        return bestTarget;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
