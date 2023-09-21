using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //serializeble for debug
    [SerializeField] private List<Item> _items;

    public void UseItem(int index)
    {

    }
    public void DeleteItem(int index)
    {
        _items.RemoveAt(index);
    }

}
