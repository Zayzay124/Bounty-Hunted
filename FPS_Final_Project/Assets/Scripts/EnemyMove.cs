//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Transform enemyBulletSpawn;
    public Transform enemy;

    public GameObject bulletPrefab;
    GameObject player;

    public int maxHealth = 100;
    int currentHealth;
    public AudioSource Stab;
    public AudioSource Shot;

    private void Start()
    {
        currentHealth = maxHealth;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0)
        {
            player = players[0];
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyStart()
    {
        InvokeRepeating("SetMoveDest", 0.1f, 1f);
        InvokeRepeating("EnemyFire", 0.1f, 1f);
    }

    public void SetMoveDest()
    {
        agent.SetDestination(player.transform.position);
    }

    void EnemyFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
    }
}
