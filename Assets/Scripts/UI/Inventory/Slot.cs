using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public event Action<Slot> OnClick;
    
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private Image _item;

    [SerializeField] private string _description;
    [SerializeField] private int _index;

    public int Index => _index;
    public bool IsEmpty { get; private set; } = true;
    public bool IsStackable { get; private set; } = true;
    public string Description => _description;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke(this);
    }

    public void Delete()
    {
        _item.gameObject.SetActive(false);
        _count.gameObject.SetActive(false);
        _description = "";
        IsEmpty = true;
    }
    public void Change(string description, int count, Sprite sprite, bool isStackable)
    {
        if (count > 1)
        {
            _count.text = count.ToString();
            _count.gameObject.SetActive(true);
        }
        else
            _count.gameObject.SetActive(false);
        IsStackable = isStackable;
        _description = description;
        _item.sprite = sprite;
        _item.gameObject.SetActive(true);
        IsEmpty = false;
    }
    public void Reload(ItemData data)
    {
        Change(data.Description, data.Count, data.Icon, data is IStackable? true : false);
    }
}
