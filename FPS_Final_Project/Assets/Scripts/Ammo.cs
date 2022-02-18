using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.localScale = new Vector3(player.GetComponent<PlayerMovement>().bulletsLoaded / 8, 1.0f, 1.0f);
    }
}
