using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizard : MonoBehaviour
{
    private Transform target;
    public float range = 10f;
    private float turnSpeed = 8f;
    private Animator wizardAnimator;

    public string enemyTag = "Enemy";

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject fireballPrefab;
    public Transform firePoint;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Start()
    {
        wizardAnimator = GetComponent<Animator>();
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
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

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            wizardAnimator.SetTrigger("attacking");
            Shoot();
            fireCountdown = 1f / fireRate;
            wizardAnimator.ResetTrigger("attacking");
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        fireball bullet = bulletGO.GetComponent<fireball>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }
}
