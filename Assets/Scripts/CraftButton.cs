using System.Linq;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
    [SerializeField] private ShopView _shop;

    private bool _productWasCrafted;

    public void TryCraftAnyProduct()
    {
        foreach (var item in _shop.Products.Sequence)
        {
            var product = item as ProductsData.Product;

            if (IsPossibleToCraftProduct(product))
            {
                Craft(product);
                Debug.Log($"{product.Name} был скрафчен!");
                _productWasCrafted = true;
            }
        }

        if (!_productWasCrafted)
            Debug.Log("Недостаточно ресурсов");

        _productWasCrafted = false;
    }

    private void Craft(ProductsData.Product product)
    {
        foreach (var material in product.CraftReceipt)
            _shop.Inventory.Remove(material);
            
        _shop.Inventory.Add(product);
    }
    
    private bool IsPossibleToCraftProduct(ProductsData.Product product)
    {
        return product.CraftReceipt.All(material => material.ContainsIn(_shop.Inventory));
    }
}
