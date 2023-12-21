using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject buyerPrefab;
    [SerializeField] float spawnRadius;
    [SerializeField] float spawnRatio;
    [SerializeField] float minDistanceBetweenBuyers;
    [SerializeField] float timeToMakeBooks;

    float timeBeforeSpawnLeft;

    private void Start()
    {
        timeBeforeSpawnLeft = spawnRatio;
    }

    private void Update()
    {
        timeBeforeSpawnLeft -= Time.deltaTime;
        if (timeBeforeSpawnLeft <= 0)
        {
            SpawnBuyer();
            timeBeforeSpawnLeft = spawnRatio;
        }
    }

    void SpawnBuyer()
    {
        var buyer = Instantiate(buyerPrefab, transform);
        var pos = ChoosePosition(0);
        buyer.transform.position = pos;
        var buyerScript = buyer.GetComponent<Buyer>();
        SetBuyerTime(buyerScript);
    }

    Vector3 ChoosePosition(int tryCount)
    {
        if (tryCount > 20) return Vector3.zero;
        Vector3 pos = new Vector3(Random.Range(-spawnRadius, spawnRadius), 1.2f, Random.Range(-spawnRadius, spawnRadius));
        Vector3 chosenPos = transform.position + pos;
        var buyersCount = transform.childCount;
        for(int i = 0; i < buyersCount; i++)
        {
            Vector3 otherBuyerPos = transform.GetChild(i).transform.position;
            if(Vector3.Distance(chosenPos, otherBuyerPos) < minDistanceBetweenBuyers)
            {
                return ChoosePosition(tryCount+1);
            }
        }
        return chosenPos;
    }

    void SetBuyerTime(Buyer buyerScript)
    {
        buyerScript.timeToCompleteTask = timeToMakeBooks;
    }

}
