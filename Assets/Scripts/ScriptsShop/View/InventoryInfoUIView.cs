using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInfoUIView : UIView
{
    [SerializeField] private EnemyFactory _enemyFactory;
    
    [SerializeField] private Image[] _materialsList;
    [SerializeField] private Image[] _productsList;

    [SerializeField] private ProductsData _productsData;
    [SerializeField] private MaterialsData _materialsData;

    private readonly List<Sprite> _productsIcons = new();
    private readonly List<Sprite> _materialsIcons = new();

    private void Awake()
    {
        DisplayItemsIcons();
        _enemyFactory.OnEnemySpawned += ListenEnemyDeath;
    }
    
    private void ListenEnemyDeath(BaseEnemy enemy)
    {
        enemy.OnDied += (enemy) =>
        {
            DisplayItemsCounters();
        };
    }

    public override void Show()
    {
        if (_productsIcons.Count == 0 && _materialsIcons.Count == 0)
        {
            foreach (var product in _productsData.Sequence)
                _productsIcons.Add(product.Icon);
        
            foreach (var material in _materialsData.Sequence)
                _materialsIcons.Add(material.Icon);
        }

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void DisplayItemsIcons()
    {
        for (var i = 0; i < _materialsList.Length; i++)
        {
            _materialsList[i].sprite = _materialsIcons[i];
        }

        for (var i = 0; i < _productsList.Length; i++)
        {
            _productsList[i].sprite = _productsIcons[i];
        }
    }
    
    private void DisplayItemsCounters()
    {
        for (var i = 0; i < _materialsList.Length; i++)
        {
            _materialsList[i].GetComponentInChildren<TextMeshProUGUI>().text = CountItemInInventory(_materialsData.Sequence[i]).ToString();
        }

        for (var i = 0; i < _productsList.Length; i++)
        {
            _productsList[i].GetComponentInChildren<TextMeshProUGUI>().text = CountItemInInventory(_productsData.Sequence[i]).ToString();
        }
    }

    private int CountItemInInventory(Items.Item item)
    {
        return ShopView.Instance.Inventory.Count(i => i == item);
    }

    private void OnDestroy()
    {
        _enemyFactory.OnEnemySpawned -= ListenEnemyDeath;
    }
}