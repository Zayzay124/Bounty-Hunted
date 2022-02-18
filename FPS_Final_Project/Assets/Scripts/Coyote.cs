using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coyote : MonoBehaviour
{
    public Vector3 lastCheckPos;
    private void OnCollisionEnter(Collision collission)
    {
        if (collission.gameObject.tag == "Coyote")
        {
            //Destroy(collission.gameObject);
            lastCheckPos = transform.position;
        }
    }
}