using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic : Enemy
{
    public override void Update(){
        base.Move();
        base.Die();
    }
}
