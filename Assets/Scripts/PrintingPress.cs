using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintingPress : MonoBehaviour
{
    public List<int> printingProductsId;
    [SerializeField] List<Pedestal> pedestals;
    [SerializeField] Pedestal resultPedestal;

    private void Start()
    {
        foreach(var pedestal in pedestals)
        {
            pedestal.ObjectPut += CheckForItemCreation;
        }
    }

    void CheckForItemCreation()
    {
        foreach (var pedestal in pedestals)
        {
            var placement = pedestal.putItem;
            if (placement == null) return;
        }
        if (resultPedestal.putItem != null) return;
        
        //if all put
        foreach (int id in printingProductsId)
        {
            var item = ItemDB.Instance.GetItem(id);
            List<int> pedestalIds = new List<int>();
            bool canCreate = true;
            foreach(var pedestal in pedestals)
            {
                var itemPart = pedestal.putItem.GetComponent<Item>();
                var itemPartId = itemPart.id;
                if(!item.reqItemIdToCreate.Contains(itemPartId)){
                    canCreate = false; 
                }
            }
            if (canCreate)
            {
                CreateItem(item.id);
                break;
            }
        }
    }

    public void CreateItem(int id)
    {
        var itemPrefab = ItemDB.Instance.GetItemPrefab(id);
        var newItem = Instantiate(itemPrefab, transform);
        SetObjectToResPedestal(newItem);
        DestroyItemsOnPedestals();
    }

    void SetObjectToResPedestal(GameObject newItem)
    {
        if(resultPedestal==null)
            PlayerManager.Instance.SetObjectToHands(newItem);
        else
        {
            resultPedestal.SetItemOnPedestal(newItem);
        }
    }

    void DestroyItemsOnPedestals()
    {
        foreach(var ped in pedestals)
        {
            ped.DestroyItemOnPedestal();
        }
    }
}
