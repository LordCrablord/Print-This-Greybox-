using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string itemName;
    public List<int> reqItemIdToCreate;

    [SerializeField] Material activeMaterial;
    [SerializeField] Material inactiveMaterial;

    public void SetInactive()
    {
        GetComponent<MeshRenderer>().material = inactiveMaterial;
    }
}
