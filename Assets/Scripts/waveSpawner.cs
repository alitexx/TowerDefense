using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public Transform enemy1;
    public Transform enemy2;

    public Transform spawnArea;

    // true is 1, false is 2
    private bool enemyToSpawn = true;

    private int waveNum = 0;

    public float timeBetweenWaves = 5f;

    private float countdown = 1f;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnEnemy());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator spawnEnemy()
    {
        waveNum++;
        for (int i = 0; i < waveNum; i++)
        {
            if (enemyToSpawn == true)
            {
                Instantiate(enemy1, spawnArea.position, spawnArea.rotation);
            } else
            {
                Instantiate(enemy2, spawnArea.position, spawnArea.rotation);
            }
            enemyToSpawn = !enemyToSpawn;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
