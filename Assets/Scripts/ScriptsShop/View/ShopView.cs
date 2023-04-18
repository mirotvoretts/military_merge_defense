using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    public static ShopView Instance;

    [SerializeField] private InventoryInfoUIView _inventoryView;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private MaterialsData _materialsData;
    [SerializeField] private ProductsData _productsData;

    private ShopPresenter _presenter;
    
    public MaterialsData Materials => _materialsData;
    public ProductsData Products => _productsData;
    
    public List<Items.Item> Inventory => _presenter.Inventory;
    
    private ShopView() { }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        
        _presenter = new ShopPresenter(this, _enemyFactory);
        _presenter.Enable();
    }

    private void OnMouseDown()
    {
        if (_inventoryView.gameObject.activeSelf)
            _inventoryView.Close();
        else
            _inventoryView.Show();
    }

    private void OnDestroy()
    {
        _presenter.Disable();
    }
}