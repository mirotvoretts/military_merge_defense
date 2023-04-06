using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Products Data", menuName = "Products Data", order = 51)]
public class ProductsData : ScriptableObject
{
    [SerializeField] private List<Product> _products;

    public List<Product> GetProducts() => _products;

    [CreateAssetMenu(fileName = "New Product", menuName = "Product", order = 52)]
    public class Product : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private uint _price;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Materials.Material[] _craftReceipt;

        public string Name => _name;
        public uint Price => _price;
    }
}
