using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] protected GameObject objectPrefab;
    protected bool isPlayerNear = false;
    protected Collider playerCollider;
    public string instrumentName;
    protected virtual void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GiveItem();
            }
        }
    }

    protected void GiveItem()
    {
        var playerManager = playerCollider.GetComponent<PlayerManager>();
        if (!playerManager.HasObjectInHands())
        {
            GameObject ourObject = Instantiate(objectPrefab, transform.position, objectPrefab.transform.rotation);
            playerManager.SetObjectToHands(ourObject);
        }
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
