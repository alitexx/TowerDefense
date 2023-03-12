using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public float speed = 10f;

    public int health = 3;
    public int startHealth = 3;
    public int moneyGainedOnDeath = 5;

    private Transform target;
    private int wavepointIndex = 0;

    public Image healthBar;


    private void Start()
    {
        target = waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position)<= 0.4f)
        {
            GetNextPoint();
        }
    }
    void GetNextPoint()
    {
        if (wavepointIndex >= waypoints.points.Length - 1)
        {
            gameStats.Lives--;
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            gameStats.coins += moneyGainedOnDeath;
            Destroy(gameObject);
        }
    }
}
