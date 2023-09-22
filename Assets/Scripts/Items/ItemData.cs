using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] protected int count = 1;
    public Sprite Icon => _icon;
    public string Name => _name;
    public string Description => _description;
    public int Count { get { return count; } set { count = value; } }

}
