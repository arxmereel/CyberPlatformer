using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private float initial_X;

    // Start is called before the first frame update
    void Start()
    {
        initial_X = transform.position.x;
    }

    public float speed = 5;
    public float X_range = 10;

    void ChangeDirection()
    {
        if (transform.position.x - initial_X <= -X_range || transform.position.x - initial_X >= X_range)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
