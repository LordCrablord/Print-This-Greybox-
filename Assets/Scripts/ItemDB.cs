using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemDB : Singleton<ItemDB>
{
    public List<Item> gameItemsList;
    public List<GameObject> gamePrefabsList;

    public GameObject GetItemPrefab(int id)
    {
        if (gamePrefabsList[id] != null)
            return gamePrefabsList[id];
        else
        {
            Debug.LogError("no item with such id");
            return null;
        }  
    }

    public Item GetItem(int id)
    {
        return gameItemsList.Find(x => x.id == id);
    }
}
