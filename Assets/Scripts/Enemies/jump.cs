using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : Enemy{
    private bool canAttack;
    private float attackTime;
    private float attackDuration;

    void Attack(){
        if (attackTime < 1000f) attackTime += 1f;

        if (attackTime >= 1000f && canAttack == false) canAttack = true;

        if (canAttack == true){
            canAttack = false;
            attackTime = 0f;
            rig.gravityScale = 0f;
        }

        if (rig.gravityScale == 0f){
            attackDuration += 1f;
        }

        if (attackDuration >= 500f){
            rig.gravityScale = 1f;
            attackDuration = 0f;
        }
    }

    public override void Update(){
        Attack();
        base.Move();
        base.Die();
    }
}
