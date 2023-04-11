using System;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoUIView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _giveProductButton;
    
    [SerializeField] private ClientView _client;
    [SerializeField] private ShopView _shop;

    public void Show()
    {
        ResetButtonWith(_closeButton, OnCloseClick);
        ResetButtonWith(_giveProductButton, OnGiveProduct);
        
        gameObject.SetActive(true);
    }

    private void ResetButtonWith(Button button, Action newListener)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => newListener());
    }

    private void OnCloseClick()
    {
        gameObject.SetActive(false);
    }

    private void OnGiveProduct()
    {
        var requestedProduct = _client.Presenter.RequestedProduct;

        Debug.Log(_shop);
        Debug.Log(_shop.Inventory);
        
        if (requestedProduct.ContainsIn(_shop.Inventory))
        {
            _client.OnProductReceived();
            _shop.Inventory.Remove(requestedProduct);
            
            OnCloseClick();
        }
        else
        {
            Debug.Log("Невозможно отдать то, чего нет!");
        }
    }
}