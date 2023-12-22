using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Buyer : MonoBehaviour
{
    public float timeToCompleteTask;
    [SerializeField] TextMeshProUGUI timerToMakeBookTMP;
    [SerializeField] Transform orderPos;
    GameObject reqObject;

    private void Update()
    {
        timeToCompleteTask -= Time.deltaTime;

        float roundedNumber = (float)Math.Floor(timeToCompleteTask * 100) / 100;
        timerToMakeBookTMP.text = roundedNumber.ToString("F2");

        if (timeToCompleteTask <= 0)
        {
            TimeRanOut();
        }
    }

    void TimeRanOut()
    {
        Destroy(gameObject);
    }

    public void SetBuyerTask(GameObject objToCreate)
    {
        objToCreate.transform.SetParent(orderPos);
        objToCreate.transform.localPosition = Vector3.zero;
        reqObject = objToCreate;

        objToCreate.GetComponent<Item>().SetInactive();
    }
}
