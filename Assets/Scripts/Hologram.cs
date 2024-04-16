using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hologram : MonoBehaviour
{
    public GameObject signUIElement;
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            signUIElement.SetActive(true);
        }
        else
        {
            signUIElement.SetActive(false);
        }
    }
}
