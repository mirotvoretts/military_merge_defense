using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoUIView : UIView
{
    [SerializeField] private TextMeshProUGUI _requestedProductLabel;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _giveProductButton;
    [SerializeField] private Button _banishButton;
    
    [SerializeField] private ClientView _client;

    private ShopView _shop;

    private void Awake()
    {
        _shop = ShopView.Instance;
        
        _requestedProductLabel.text = _client.Presenter.RequestedProduct.Name;
    }

    public override void Show()
    {
        ResetButtonWith(_closeButton, Close);
        ResetButtonWith(_giveProductButton, OnGiveProduct);
        ResetButtonWith(_banishButton, Banish);
        
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void Banish()
    {
        _client.OnProductReceived();
        Close();
    }

    private void OnGiveProduct()
    {
        var requestedProduct = _client.Presenter.RequestedProduct;

        if (requestedProduct.ContainsIn(_shop.Inventory))
        {
            ShopView.Instance.Inventory.Remove(requestedProduct);
            
            _client.OnProductReceived();
            Score.OnSell(requestedProduct);

            Close();
        }
        else
        {
            Debug.Log("Невозможно отдать то, чего нет!");
        }
    }
}