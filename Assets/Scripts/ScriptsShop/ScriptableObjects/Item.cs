using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] protected string _name;
    [SerializeField] protected Sprite _icon;

    public string Name => _name;
    public Sprite Icon => _icon;
}
