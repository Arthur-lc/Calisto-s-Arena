using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : Enemy
{
    public bool folowing;
    public override void Update()
    {
        base.Update();

        /*if (folowing) 
            base.Follow(base.player.transform);
        //else
            //base.GetAway(base.player.transform);*/
    }

    private void FixedUpdate() {
        base.Follow(base.player.transform);
    }

}
