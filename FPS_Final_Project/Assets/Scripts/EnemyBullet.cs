using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletPrefab;

    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 4f);
    }

    
    void Update()
    {
        rb.velocity = transform.forward * 80;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Hit");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
