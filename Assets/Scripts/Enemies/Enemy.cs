using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{
    [SerializeField] protected float speed;
    [SerializeField] protected int health;
    [SerializeField] protected int score;

    private float timer;

    public GameObject enemy;
    public Animator anim;
    public Rigidbody2D rig;
    public float attackRange_X = 3;
    private float attackRange_Y = 2;

    public virtual void Start(){
        enemy = GameObject.Find("Player Ball");
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }
    
    public virtual void Die(){
        if (health <= 0){
            anim.Play("die");
            Destroy(gameObject, 5f);
        }
        if (enemy.transform.position.x < transform.position.x + attackRange_X && enemy.transform.position.x > transform.position.x - attackRange_X)
        {
            if (enemy.transform.position.y < transform.position.y + attackRange_Y && enemy.transform.position.y > transform.position.y - attackRange_Y)
            {
                Debug.Log("In range for attack");
                if (Input.GetKeyDown("left shift"))
                {
                    Debug.Log("Attacked");
                    anim.Play("die");
                    Destroy(gameObject);
                }
            }
        }
    }

    public virtual void Move(){
        transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
    }    

    public abstract void Update();
}