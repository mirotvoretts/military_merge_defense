using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Products Data", menuName = "Products Data", order = 51)]
public class ProductsData : Items
{
    [CreateAssetMenu(fileName = "New Product", menuName = "Product", order = 52)]
    public class Product : Item
    {
        [SerializeField] private uint _price;
        [SerializeField] private MaterialsData.Material[] _craftReceipt;
        
        public uint Price => _price;
        public IEnumerable<MaterialsData.Material> CraftReceipt => _craftReceipt;
        
        public bool ContainsIn(IEnumerable<Item> products)
        {
            return products.Contains(this);
        }
    }
}
