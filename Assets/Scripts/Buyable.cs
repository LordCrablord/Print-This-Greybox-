using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyable : MonoBehaviour
{
    [SerializeField] GameObject activeObject;
    [SerializeField] GameObject inactiveObject;
    public int priceToBuy = 0;
    protected bool isPlayerNear = false;
    protected Collider playerCollider;

    protected virtual void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryToBuy();
            }
        }
    }

    void TryToBuy()
    {
        activeObject.SetActive(true);
        inactiveObject.SetActive(false);
        if(GameManager.Instance.Gold>=priceToBuy)
            GameManager.Instance.Gold -= priceToBuy;
    }

    void SetUITip(bool visible)
    {
        /*var ui = GameManager.Instance.GetUI();
        ui.SetTipString(visible, instrumentName);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() == null) return;
        isPlayerNear = true;
        playerCollider = other;
        SetUITip(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() == null) return;
        isPlayerNear = false;
        playerCollider = null;
        SetUITip(false);
    }
}
