using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{

    public GameObject enemy;

    public float timer = 2.0f;
    public float wait = 6.0f;

    public int waveNum = 0;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 1)
        {
            StartCoroutine(SpawnWave());
            timer = 60.0f;
        }

        timer -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveNum++;

        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.75f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
