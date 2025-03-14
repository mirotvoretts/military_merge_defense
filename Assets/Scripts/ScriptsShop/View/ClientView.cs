﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClientView : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject _sprite;
    [SerializeField] private ProductsData _productsData;
    [SerializeField] private Transform _shop;
    [SerializeField] private ClientInfoUIView _infoMenu;

    public ClientPresenter Presenter { get; private set; }
    public Action<IClickable> OnClicked { get; set; }
    public GameObject Sprite => _sprite;

    public void OnProductReceived() => Presenter.InvokeOnProductReceived();

    private void Awake()
    {
        Presenter = new ClientPresenter(this, _shop, _productsData);
        Presenter.Enable();
    }

    private void Update()
    {
        Presenter.MoveToEndOfQueue();
        if (Presenter.ProductReceived) Presenter.MoveOutOfQueue();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (_infoMenu.gameObject.activeSelf)
            _infoMenu.Close();
        else if (IsFirstInQueue())
            _infoMenu.Show();
    }

    private bool IsFirstInQueue()
    {
        return this == QueueOfClients.Peek();
    }

    private void OnDestroy()
    {
        Presenter.Disable();
    }
}