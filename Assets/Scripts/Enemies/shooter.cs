using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : Enemy
{
    public GameObject bullet;
    public float rof;
    private bool canAttack;
    private float attackTime;
    private float distance;
    
    public override void Start(){
        base.Start();
        canAttack = true;
        attackTime = 0;
        distance = Vector2.Distance(transform.position, enemy.transform.position);
    }

    void Attack(){
        distance = Vector2.Distance(transform.position, enemy.transform.position);

        if (attackTime < 1000f) attackTime += 1f;

        if (attackTime >= 1000f && canAttack == false) canAttack = true;

        if (distance <= rof && canAttack){
            canAttack = false;
            attackTime = 0f;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    public override void Update(){
        Attack();
        base.Move();
        base.Die();
    }
}
