using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") >= 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxis("Vertical") * speed);
        }
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);
    }
}
