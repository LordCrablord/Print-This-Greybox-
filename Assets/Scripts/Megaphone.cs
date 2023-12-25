using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : Interactable
{
    [SerializeField] int usageCost;
    [SerializeField] float timeIncrease;
    protected override void Interact(PlayerManager playerManager)
    {
        if (GameManager.Instance.Gold < usageCost) return;
        BuyerSpawnManager.Instance.IncreaseTimeOfTasks(timeIncrease);
        GameManager.Instance.Gold -= usageCost;
    }
}
