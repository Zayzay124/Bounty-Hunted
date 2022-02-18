using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour
{
    List<GameObject> Enemies;

    private void Start()
    {
        Enemies = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemies.Add(other.gameObject);
            return;
        }
        else if(!other.CompareTag("Player"))
        {
            return;
        }
        foreach(GameObject i in Enemies)
        {
            i.GetComponent<EnemyMove>().EnemyStart();
            Debug.Log("Enemy Start");
        }
    }
}
