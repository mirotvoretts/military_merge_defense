using System.Linq;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
    [SerializeField] private ShopView _shop;

    private bool _anyProductWasCrafted;

    public void TryCraftAnyProduct()
    {
        foreach (var item in _shop.Products.Sequence)
        {
            var product = (ProductsData.Product)item;

            if (IsPossibleToCraftProduct(product))
            {
                Craft(product);
                Debug.Log($"{product.Name} был скрафчен!");
                _anyProductWasCrafted = true;
            }
        }

        if (!_anyProductWasCrafted)
            Debug.Log("Недостаточно ресурсов");

        _anyProductWasCrafted = false;
    }

    private bool IsPossibleToCraftProduct(ProductsData.Product product)
    {
        return product.CraftReceipt.All(material => material.ContainsIn(ShopView.Instance.Inventory));
    }
    
    private void Craft(ProductsData.Product product)
    {
        foreach (var material in product.CraftReceipt)
            ShopView.Instance.Inventory.Remove(material);
            
        ShopView.Instance.Inventory.Add(product);
    }
}
