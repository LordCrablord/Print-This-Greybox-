using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerSpawnManager : Singleton<BuyerSpawnManager>
{
    [SerializeField] GameObject buyerPrefab;
    [SerializeField] float spawnRadius;
    [SerializeField] float spawnRatio;
    [SerializeField] float spawnRatioRandomise;
    [SerializeField] float minDistanceBetweenBuyers;
    [SerializeField] float timeToMakeBooks;
    [SerializeField] float bookTimeRandomise;
    [SerializeField] float goldReward;
    [SerializeField] float goldRandomise;
    [SerializeField] float lateGoldRewardIncrease;

    [SerializeField] List<GameObject> startGameOrdersList;
    [SerializeField] List<GameObject> lateGameOrdersList;
    [SerializeField] List<GameObject> midGameOrdersList;
    [SerializeField] float lateGameTimer;
    [SerializeField] float midGameTimer;

    List<GameObject> orderslist;

    float timeBeforeSpawnLeft;

    private void Start()
    {
        timeBeforeSpawnLeft = 3f;
        orderslist = new List<GameObject>();
        SetOrderList(startGameOrdersList);
    }

    void SetOrderList(List<GameObject> additions)
    {
        foreach (var newObj in additions)
            orderslist.Add(newObj);
    }

    private void Update()
    {
        timeBeforeSpawnLeft -= Time.deltaTime;
        if (timeBeforeSpawnLeft <= 0)
        {
            SpawnBuyer();
            timeBeforeSpawnLeft = FigureSpawnime();
        }

        ManageGameTimers();
    }

    void ManageGameTimers()
    {
        midGameTimer -= Time.deltaTime;
        if (midGameTimer <= 0)
            SetOrderList(midGameOrdersList);

        lateGameTimer -= Time.deltaTime;
        if (lateGameTimer <= 0)
        {
            SetOrderList(lateGameOrdersList);
        }
    }

    float FigureSpawnime()
    {
        var ourRatio = spawnRatio + Random.Range(-spawnRatioRandomise, spawnRatioRandomise);
        return ourRatio;
    }

    void SpawnBuyer()
    {
        var buyer = Instantiate(buyerPrefab, transform);
        var pos = ChoosePosition(0);
        buyer.transform.position = pos;
        var buyerScript = buyer.GetComponent<Buyer>();
        SetBuyerTime(buyerScript);
        SetBuyerObject(buyerScript);
        SetBuyerGoldReward(buyerScript);
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
        var buyerTime = timeToMakeBooks + Random.Range(-bookTimeRandomise, bookTimeRandomise);
        buyerScript.timeToCompleteTask = buyerTime;
    }

    void SetBuyerObject(Buyer buyerScript)
    {
        var index = Random.Range(0, orderslist.Count);
        var objToCreate = Instantiate(orderslist[index]);
        buyerScript.SetBuyerTask(objToCreate);
    }

    void SetBuyerGoldReward(Buyer buyerScript)
    {
        var gold = (int)(goldReward + Random.Range(-goldRandomise, goldRandomise));
        buyerScript.taskGoldReward = gold;
        buyerScript.SetGoldUI(gold);
    }

    public void IncreaseTimeOfTasks(float time)
    {
        int index = transform.childCount;
        for (int i = 0; i< index; i++)
        {
            var buyer = transform.GetChild(i).GetComponent<Buyer>();
            buyer.IncreaseTimeLeft(time);
        }
    }
}
