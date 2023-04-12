using System;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoUIView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _giveProductButton;
    
    [SerializeField] private ClientView _client;
    
    private ShopView _shop;

    private void Awake()
    {
        _shop = ShopView.Instance;
    }

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

        if (requestedProduct.ContainsIn(_shop.Inventory))
        {
            ShopView.Instance.Inventory.Remove(requestedProduct);
            _client.OnProductReceived();

            OnCloseClick();
        }
        else
        {
            Debug.Log("Невозможно отдать то, чего нет!");
        }
    }
}