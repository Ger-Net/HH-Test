using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Slot[] _slots;
    [SerializeField] private DeleteButton _deleteButton;
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
        _description.text = "";
    }
    private void ShowAction(Slot slot)
    {
        if (slot.IsEmpty)
            return;
        _deleteButton.gameObject.SetActive(true);
        _deleteButton.SetSlot(slot);
        _description.text = slot.Description;
    }
    public void HideActions()
    {
        _deleteButton.gameObject.SetActive(false);
    }
}
