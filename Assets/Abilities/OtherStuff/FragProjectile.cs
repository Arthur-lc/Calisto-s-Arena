using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragProjectile : Projectile
{
    public GameObject projectile;
    public override void DealDamage(Killable target) {
        base.DealDamage(target);
        
        if (target.isDead)
        {
            for (int i = 0; i < abilitylvl; i++)
            {
                Quaternion newRotation = Random.rotation;
                newRotation = Quaternion.Euler(0, 0, newRotation.eulerAngles.y);
                GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.Euler(Vector3.forward * Random.Range(0, 360)));
                Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), target.GetComponent<Collider2D>(), false); 
                //newProjectile.SetActive(true);
            }
        }
    }
}
