using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Notify();
public class Pedestal : MonoBehaviour
{
    public Transform center;

    public List<int> reqitemIdToPut;

    public GameObject putItem;
    protected bool isPlayerNear = false;
    protected Collider playerCollider;
    public event Notify ObjectPut;
    protected virtual void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryPuttingItem(playerCollider.GetComponent<PlayerManager>());
            }
        }
    }

    public void TryPuttingItem(PlayerManager playerManager)
    {
        if(!playerManager.HasObjectInHands())
        {
            playerManager.SetObjectToHands(putItem);
            putItem = null;
        }
        else
        {
            GameObject objectToPut = playerManager.objectInHands;
            var objectToPutScript = objectToPut.GetComponent<Item>();

            if (CheckIfCorrectItem(objectToPutScript.id))
            {
                var temp = putItem;
                putItem = playerManager.objectInHands;
                putItem.transform.SetParent(center);
                putItem.transform.localPosition = Vector3.zero;
                playerManager.SetObjectToHands(temp);
            }
        }
    }

    bool CheckIfCorrectItem(int itemId)
    {
        if (reqitemIdToPut.Count == 0) return true;
        return reqitemIdToPut.Contains(itemId) ? true : false;
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

    protected virtual void OnObjectPut()
    {
        ObjectPut?.Invoke();
    }
}
