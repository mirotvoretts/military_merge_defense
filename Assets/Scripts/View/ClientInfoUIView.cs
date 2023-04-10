using System;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoUIView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _giveProductButton;

    [SerializeField] private ClientView _client;

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
        _client.OnProductReceived();
        OnCloseClick();
    }
}