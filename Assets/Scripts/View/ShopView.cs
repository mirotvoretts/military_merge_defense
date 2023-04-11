using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private MaterialsData _materialsData;
    [SerializeField] private ProductsData _productsData;

    private ShopPresenter _presenter;
    
    public MaterialsData Materials => _materialsData;
    public ProductsData Products => _productsData;
    
    public List<Items.Item> Inventory => _presenter.Inventory;
    
    private void Awake()
    {
        _presenter = new ShopPresenter(this, _enemyFactory);
        _presenter.Enable();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == Config.Mouse1Id)
        {
            Debug.Log(_presenter.Inventory[^1].Name);
        }
    }

    private void OnDestroy()
    {
        _presenter.Disable();
    }
}