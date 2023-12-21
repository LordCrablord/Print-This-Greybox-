using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldTMP;
    public void SetGold(int newVal)
    {
        goldTMP.text = newVal.ToString();
    }
}
