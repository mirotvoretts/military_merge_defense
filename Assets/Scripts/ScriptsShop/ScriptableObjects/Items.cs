using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Items : ScriptableObject
{
    [SerializeField] protected List<Item> _sequence;
    public List<Item> Sequence => _sequence;

    public abstract class Item : ScriptableObject
    {
        [SerializeField] protected string _name;
        [SerializeField] protected Sprite _icon;
        
        public string Name => _name;
        public Sprite Icon => _icon;
    }
}
