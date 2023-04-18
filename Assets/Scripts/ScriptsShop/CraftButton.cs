using System.Linq;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
    [SerializeField] private ShopView _shop;

    private bool _anyProductWasCrafted;

    public void TryCraftRequestedProduct()
    {
        var firstClient = QueueOfClients.Peek();

        if (firstClient == null)
        {
            //Debug.Log("Очередь пуста!");
        }
        else if (ShopView.Instance.Inventory.Contains(firstClient.Presenter.RequestedProduct))
        {
            //Debug.Log("Продукт уже скрафчен! Пора отдавать!");
        }
        else if (IsPossibleToCraftProduct(firstClient.Presenter.RequestedProduct))
        {
            Craft(firstClient.Presenter.RequestedProduct);
           // Debug.Log($"{firstClient.Presenter.RequestedProduct.Name} был скрафчен!");
        }
        else
        {
            //Debug.Log("Недостаточно ресурсов, чтобы выполнить заказ!");
        }
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
