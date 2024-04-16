using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : Enemy
{
    private Vector2 destination;

    public override void Start(){
        base.Start();
        destination = enemy.transform.position;
    }

    public override void Move(){
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    public override void Die(){
        if (transform.position.x == destination.x && transform.position.y == destination.y) Destroy(gameObject, 1f);
    }

    public override void Update(){
        Move();
        Die();
    }
}
