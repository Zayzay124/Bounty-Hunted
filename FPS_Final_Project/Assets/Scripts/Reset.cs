using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject player;
    public Vector3 lastCheckPos;


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            lastCheckPos = transform.position;
            Debug.Log("CheckPoint");
            player.GetComponent<PlayerMovement>().GoLastCheck();
        }
    }
}
