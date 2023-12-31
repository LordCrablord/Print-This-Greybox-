using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Buyer : MonoBehaviour
{
    public float timeToCompleteTask;
    public int taskGoldReward;
    [SerializeField] TextMeshProUGUI timerToMakeBookTMP;
    [SerializeField] TextMeshProUGUI goldTMP;
    [SerializeField] Transform orderPos;
    GameObject reqObject;
    string reqObjName;
    CreateHelpUI createHelpUI;
    private void Update()
    {
        timeToCompleteTask -= Time.deltaTime;

        float roundedNumber = (float)Math.Floor(timeToCompleteTask * 100) / 100;
        timerToMakeBookTMP.text = roundedNumber.ToString("F2");

        createHelpUI.bookNameTMP.text = reqObjName;
        createHelpUI.timeLeftTMP.text = roundedNumber.ToString("F2");

        if (timeToCompleteTask <= 0)
        {
            TimeRanOut();
        }
    }

    void TimeRanOut()
    {
        GameManager.Instance.Lives--;
        Destroy(gameObject);
        Destroy(createHelpUI.gameObject);
    }

    public void SetBuyerTask(GameObject objToCreate)
    {
        objToCreate.transform.SetParent(orderPos);
        objToCreate.transform.localPosition = Vector3.zero;
        reqObject = objToCreate;
        reqObjName = objToCreate.GetComponent<Item>().itemName;

        objToCreate.GetComponent<Item>().SetInactive();
    }

    public void SetTaskHelpUI(CreateHelpUI helpUI)
    {
        createHelpUI = helpUI;
    }

    public void CheckIfCorrectObject(PlayerManager playerManager)
    {
        if (playerManager.HasObjectInHands() == false) return;

        var checkingObjScript = playerManager.objectInHands.GetComponent<Item>();
        var reqObjectScript = reqObject.GetComponent<Item>();

        if(checkingObjScript.id == reqObjectScript.id)
        {
            playerManager.SetObjectToHands(null);
            Destroy(checkingObjScript.gameObject);
            TaskComplete();
        }

    }

    void TaskComplete()
    {
        GameManager.Instance.Gold += taskGoldReward;
        Destroy(gameObject);
        Destroy(createHelpUI.gameObject);
    } 

    public void IncreaseTimeLeft(float time)
    {
        timeToCompleteTask += time;
    }

    public void SetGoldUI(int value)
    {
        goldTMP.text = value.ToString();
    }
}
