using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    private GameObject player;
    public string masterKey;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ball");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
