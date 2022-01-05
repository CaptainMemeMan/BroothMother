using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCurrency : MonoBehaviour
{
    public int energy = 100;

    public int currentEnergy = 0;

    public int credits = 1;

    private Vector3 enemyPos; 

    private bool dropOnce = false;


    [Header("Credit")]

    [SerializeField] protected Credit creditPrefab;

    [SerializeField] protected int creditVal;

    void Start()
    {
        currentEnergy = energy;
        creditVal = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DamageRobot(50);
        }
    }



    public void DamageRobot(int damage)
    {
        currentEnergy -= damage;

        if (currentEnergy <= 0 && dropOnce == false)
        {
            InstantiateCredit();

            Destroy(gameObject);

            dropOnce = true;
        }
    }



    protected virtual void InstantiateCredit()
    {
        enemyPos = gameObject.transform.position;

        var rndX = Random.Range(0, 3);

        var rndY = Random.Range(0, 3);

        enemyPos.x += rndX;

        enemyPos.y += rndY;

        var credit = Instantiate(creditPrefab.gameObject, enemyPos, Quaternion.identity);

        credit.GetComponent<Credit>().SetCreditValue(creditVal);
    }

}
