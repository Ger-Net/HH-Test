using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryManager _manager;
    //serializable for debug
    [SerializeField] private ItemData[] _items;
    [SerializeField] private int _maxCount;
    [SerializeField] private SpriteRenderer _weaponView;
    public Weapon Weapon {get; private set;}
    public void TakeItem(Item item)
    {
        if(_items.Any(t => t != null && t.Equals(item.Data) && t is IStackable))
        {
            _items.FirstOrDefault(t=>t.Equals(item.Data)).Count+= item.Data.Count;
            _manager.Put(item.Data);
            Destroy(item.gameObject);
            return;
        }
        Debug.Log("First");

        for (int i = 0; i < _maxCount; i++)
        {
            if (_items[i] == null)
            {
                Debug.Log("Find");
                _items[i] = item.Data;
                if(_items[i] is IStackable)
                    _manager.Put(item.Data);
                else
                    _manager.Put(item.Data,false);
                Destroy(item.gameObject);
                return;
            }
        }
        Debug.Log("Not enough space");


    }
    public void Reload(int index,ItemData data)
    {
        _manager.Reload(index,data);
    }
    public void UseItem(int index)
    {
        if (_items[index] is Weapon)
        {
            Weapon = _items[index] as Weapon;
            _weaponView.gameObject.SetActive(true);
            _weaponView.sprite = Weapon.Icon;
        }
            
        if (_items[index] is Medical)
        {
            (_items[index] as Medical).Heal();
            Reload(index, _items[index]);
            if (_items[index].Count == 0)
            {
                _manager.Delete(index);
            }
                
            
        }
            
    }
    public void DeleteItem(int index)
    {
        _items[index] = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Item item))
            TakeItem(item);
    }
}
