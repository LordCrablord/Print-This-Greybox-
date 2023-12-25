using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldTMP;
    [SerializeField] TextMeshProUGUI livesTMP;
    public void SetGold(int newVal)
    {
        goldTMP.text = newVal.ToString();
    }

    public void SetLives(int newVal)
    {
        livesTMP.text = $"Lives: {newVal}/{GameManager.Instance.MaxLives}";
    }
}
