using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour
{
    private float initial_Y;
    public float delay = 2f;
    private float bottom_Y = -20;
    public float fallMult = 5f;
    private bool falling = false;
    public float respawnDelay = 0f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        initial_Y = transform.position.y;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Fall()
    {
        falling = true;
        transform.position += Vector3.down * fallMult * Time.deltaTime;
    }

    void Respawn()
    {
        transform.position += new Vector3(0, initial_Y - transform.position.y, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", delay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= bottom_Y)
        {
            falling = false;
            Invoke("Respawn", respawnDelay);
        }
        else if (falling)
        {
            Fall();
        }
    }
}
