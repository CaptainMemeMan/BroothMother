using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCurrency : MonoBehaviour
{
    public int credits = 1;

    private Vector3 enemyPos;

    private bool dropOnce = false;

    public EnemyPath currHealth;


    [Header("Credit")]

    [SerializeField] protected Credit creditPrefab;

    [SerializeField] protected int creditVal;


    void Start()
    {
        currHealth = GetComponent<EnemyPath>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currHealth.updatehealth(1);
            DropCredit();
        }
    }



    public void DropCredit()
    {

        if (currHealth.health <= 0 && dropOnce == false)
        {
            InstantiateCredit();

            //Destroy(gameObject);

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
