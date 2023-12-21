using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Buyer : MonoBehaviour
{
    public float timeToCompleteTask;
    [SerializeField] TextMeshProUGUI timerToMakeBookTMP;

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
}
