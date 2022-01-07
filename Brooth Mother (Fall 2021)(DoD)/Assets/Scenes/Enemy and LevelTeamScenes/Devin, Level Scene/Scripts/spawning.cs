using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{

    public GameObject enemy;

    public float timer = 2.0f;
    public float wait = 6.0f;
    public bool over = false;
    public int waveNum = 0;

    // Update is called once per frame



    public void earlywave(){
        StartCoroutine(SpawnWave());
    }


   public IEnumerator SpawnWave()
    {
        waveNum++;

        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.75f);
        }

    }

   public void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
