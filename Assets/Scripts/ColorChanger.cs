using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : Interactable
{
    [SerializeField] int colorId;
    [SerializeField] int goldPrice;
    protected override void Interact(PlayerManager playerManager)
    {
        if (GameManager.Instance.Gold < goldPrice) return;
        var obj = playerManager.objectInHands;
        if (obj == null) return;
        var objectToCreate = ItemDB.Instance.GetItem(colorId);
        if (objectToCreate.reqItemIdToCreate.Contains(obj.GetComponent<Item>().id))
        {
            var prefab = ItemDB.Instance.GetItemPrefab(colorId);
            var ourColor = Instantiate(prefab, transform);
            Destroy(obj);
            playerManager.SetObjectToHands(ourColor);
            GameManager.Instance.Gold -= goldPrice;
        }
    }
}
