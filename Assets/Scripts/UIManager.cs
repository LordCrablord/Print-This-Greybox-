using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldTMP;
    [SerializeField] TextMeshProUGUI livesTMP;
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject helpUI;
    public void SetGold(int newVal)
    {
        goldTMP.text = newVal.ToString();
    }

    public void SetLives(int newVal)
    {
        livesTMP.text = $"Lives: {newVal}/{GameManager.Instance.MaxLives}";
    }

    public void RestartClicked()
    {
        GameManager.Instance.RestartGame();
    }

    public void QuitClicked()
    {
        GameManager.Instance.QuitGame();
    }

    public void SetMenu()
    {
        menuUI.SetActive(!menuUI.activeInHierarchy);
    }

    public void SetHelp()
    {
        helpUI.SetActive(!helpUI.activeInHierarchy);
    }
}
