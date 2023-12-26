using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Megaphone : Interactable
{
    [SerializeField] int usageCost;
    [SerializeField] float timeIncrease;
    [SerializeField] float cooldown;
    [SerializeField] TextMeshProUGUI cooldownTMP;

    float currCooldown = 0f;

    protected override void Update()
    {
        if (currCooldown > 0)
        {
            cooldownTMP.gameObject.SetActive(true);
            currCooldown -= Time.deltaTime;
            float roundedNumber = (float)Math.Floor(currCooldown * 100) / 100;
            cooldownTMP.text = $"cooldown: {roundedNumber.ToString("F2")}";
        }
        else
        {
            cooldownTMP.gameObject.SetActive(false);
            base.Update();
        }
    }
    protected override void Interact(PlayerManager playerManager)
    {
        if (GameManager.Instance.Gold < usageCost) return;
        BuyerSpawnManager.Instance.IncreaseTimeOfTasks(timeIncrease);
        GameManager.Instance.Gold -= usageCost;

        currCooldown = cooldown;
    }
}
