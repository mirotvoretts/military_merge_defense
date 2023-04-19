using System;
using System.Linq;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
    public Action ItemCrafted { get; set; }

    private NoticeUIView _notice;
    private bool _anyProductWasCrafted;

    private void Awake()
    {
        _notice = NoticeUIView.Instance;
    }

    public void TryCraftRequestedProduct()
    {
        var firstClient = QueueOfClients.Peek();

        if (firstClient == null)
        {
            _notice.Show("Очередь пуста!");

        }
        else if (ShopView.Instance.Inventory.Contains(firstClient.Presenter.RequestedProduct))
        {
            _notice.Show("Продукт уже скрафчен! Пора отдавать!");
        }
        else if (IsPossibleToCraftProduct(firstClient.Presenter.RequestedProduct))
        {
            Craft(firstClient.Presenter.RequestedProduct);
            _notice.Show($"{firstClient.Presenter.RequestedProduct.Name} был скрафчен!");
        }
        else
        {
            _notice.Show("Недостаточно ресурсов, чтобы выполнить заказ!");
        }
    }

    private bool IsPossibleToCraftProduct(Product product)
    {
        return product.CraftReceipt.All(material => material.ContainsIn(ShopView.Instance.Inventory));
    }
    
    private void Craft(Product product)
    {
        foreach (var material in product.CraftReceipt)
            ShopView.Instance.Inventory.Remove(material);
            
        ShopView.Instance.Inventory.Add(product);
        
        ItemCrafted?.Invoke();
    }
}
