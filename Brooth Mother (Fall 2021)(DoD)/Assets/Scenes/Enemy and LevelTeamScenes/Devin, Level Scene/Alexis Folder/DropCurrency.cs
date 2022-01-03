using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCurrency : MonoBehaviour
{
    public int energy = 100;

    public int currentEnergy = 0;

    public int credits = 1;

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
            DamageRobot(10);
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
        var position = Random.insideUnitSphere;
        var credit = Instantiate(creditPrefab.gameObject, position, Quaternion.identity);

        credit.GetComponent<Credit>().SetCreditValue(creditVal);
    }

}
