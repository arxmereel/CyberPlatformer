using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    [Range(1, 10)]
    public float jumpVelocity;
    public float fallMult = 2.5f;
    public float lowJumpMult = 2f;
    public string targetscenename;
    private int jumps;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    public List<string> keys;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        jumps++;
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;
        }
    }

    void Move()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX* speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && rb.velocity.y == 0 && collision.gameObject.transform.position.y < transform.position.y)
        {
            jumps = 0;
        }
        if (collision.gameObject.CompareTag("Door") && keys.Count > 0)
        {
            keys.RemoveAt(0);
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene(targetscenename);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            keys.Add(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jumps < 2)
        {
            Jump();
        }
        
        BetterJump();

        if(dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
        if (Input.GetKeyDown("left shift"))
        {
            anim.SetBool("attacking", true);
        }
        else
        {
            anim.SetBool("attacking", false);
        }
    }
}
