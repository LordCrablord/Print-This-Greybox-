using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintingPress : MonoBehaviour
{
    public List<int> printingProductsId;
    [SerializeField] List<Pedestal> pedestals;

    private void Start()
    {
        foreach(var pedestal in pedestals)
        {
            pedestal.ObjectPut += CheckForItemCreation;
        }
    }

    void CheckForItemCreation()
    {

    }

    public void CreateItem()
    {
        //put items on pedestals
        //get item ids of what on pedestal
        //if all of them are req list of things, make shit and put it in on pedestal three
    }
}
