using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject Player;
    private float playerY;
    public bool horiz = true;
    public bool vert = true;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveCamera()
    {
        offset = new Vector3(0, 0, -10);
        if (horiz && !vert) {
            transform.position = Player.transform.position + new Vector3(0, -Player.transform.position.y, -10); 
        }
        else if (!horiz && vert) {
            transform.position = Player.transform.position + new Vector3(-Player.transform.position.x, 0, -10); 
        }
        else if (horiz && vert)
        {
            transform.position = Player.transform.position + offset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
}
