using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject tank;

    public GameObject fast;

    public GameObject enemy;

    private GameObject[] enemyObjects;

    public float timer = 2.0f;
    public float wait = 6.0f;
    public bool over = false;
    public int waveNum = 0;

    public bool enemiesOnScreen = false;

    // Update is called once per frame
    public void Update()
    {
        enemyObjects = findEnemys();

        if(enemyObjects.Length > 0)
        {
            enemiesOnScreen = true;
        }
        else
        {
            enemiesOnScreen = false;
        }
    }


    public void earlywave(){
        if (enemiesOnScreen == false)
        {
            StartCoroutine(SpawnWave());
        }
    }


   public IEnumerator SpawnWave()
    {
        waveNum++;

        if (waveNum % 3 == 0)
        {
            for (int i = 0; i < waveNum / 3; i++)
            {
                SpawnTank();
                yield return new WaitForSeconds(1.0f);
            }
        }

        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.75f);
        }

        if (waveNum % 2 == 0)
        {
            for (int i = 0; i < waveNum / 2; i++)
            {
                SpawnFast();
                yield return new WaitForSeconds(0.5f);
            }
        }

    }

   private void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    private void SpawnTank()
    {
        Instantiate(tank, transform.position, Quaternion.identity);
    }

    private void SpawnFast()
    {
        Instantiate(fast, transform.position, Quaternion.identity);
    }

    private GameObject[] findEnemys()
    {
        return GameObject.FindGameObjectsWithTag("enemy");
    }
}
