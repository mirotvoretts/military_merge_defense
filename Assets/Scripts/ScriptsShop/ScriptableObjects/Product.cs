using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Product", order = 52)]
public class Product : Item
{
    [SerializeField] private int _price;
    [SerializeField] private CraftMaterial[] _craftReceipt;

    public int Price => _price;
    public IEnumerable<CraftMaterial> CraftReceipt => _craftReceipt;

    public bool ContainsIn(IEnumerable<Item> products)
    {
        return products.Contains(this);
    }
}