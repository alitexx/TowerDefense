using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public float speed = 10f;

    public float health = 3f;
    public float startHealth = 3f;
    public int moneyGainedOnDeath = 5;
    public int damageDealt = 1;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    private Transform WPTarget;
    private Transform target;
    private int wavepointIndex = 0;

    public Image healthBar;


    private void Start()
    {
        WPTarget = waypoints.points[0];
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        Vector3 direction = WPTarget.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, WPTarget.position)<= 0.4f)
        {
            GetNextPoint();
        }

        if (target == null)
        {
            return;
        }
        // a target has been found
        if (fireCountdown <= 0f)
        {
            target.GetComponent<wizard>().wizardTakeDamage(damageDealt);
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
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
        WPTarget = waypoints.points[wavepointIndex];
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


    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Wizard");
        if (enemies == null)
        {
            target = null;
            return;
        }
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= 8f)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


}
