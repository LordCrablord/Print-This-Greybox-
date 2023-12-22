using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintingPress : MonoBehaviour
{
    public List<int> printingProductsId;
    [SerializeField] List<Pedestal> pedestals;
    //[SerializeField] Transform placeOfCreation;

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
        PlayerManager.Instance.SetObjectToHands(newItem);
        DestroyItemsOnPedestals();
        //put items on pedestals
        //get item ids of what on pedestal
        //if all of them are req list of things, make shit and put it in on pedestal three
    }

    void DestroyItemsOnPedestals()
    {
        foreach(var ped in pedestals)
        {
            ped.DestroyItemOnPedestal();
        }
    }
}
