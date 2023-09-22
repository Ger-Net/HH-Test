using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Slot[] _slots;
    [SerializeField] private DeleteButton _deleteButton;
    [SerializeField] private UseButton _useButton;
    [SerializeField] private TextMeshProUGUI _description;
    private void Awake()
    {
        foreach(Slot slot in _slots)
        {
            slot.OnClick += ShowAction;
        }
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
        HideActions();
        _description.text = "";
    }
    public void HideActions()
    {
        _deleteButton.gameObject.SetActive(false);
        _useButton.gameObject.SetActive(false);
    }
    public void Put(ItemData itemData, bool isStackable = true)
    {
        var slot = _slots.FirstOrDefault(t => (t.Description == itemData.Description && t.IsStackable) || t.IsEmpty);
        slot.Change(itemData.Description, itemData.Count, itemData.Icon, isStackable);
    } 
    public void Delete(int index)
    {
        _slots[index].Delete();
    }
    public void Reload(int index, ItemData data)
    {
        _slots[index].Reload(data);
    }
    private void ShowAction(Slot slot)
    {
        if (slot.IsEmpty)
            return;
        _deleteButton.gameObject.SetActive(true);
        _useButton.gameObject.SetActive(true);
        _deleteButton.SetSlot(slot);
        _useButton.SetSlot(slot);
        _description.text = slot.Description;
    }
}
