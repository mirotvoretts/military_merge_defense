using System.Collections.Generic;
using UnityEngine;

public class ShopPresenter : IPresenter
{
    private readonly Shop _model;
    private readonly ShopView _view;
    
    private readonly EnemyFactory _enemyFactory;
    
    public List<Items.Item> Inventory => _model.Inventory;
    
    public ShopPresenter(ShopView view, EnemyFactory enemyFactory)
    {
        _model = Shop.GetInstance();
        _view = view;
        _enemyFactory = enemyFactory;
    }
    
    public void Enable()
    {
        _enemyFactory.EnemyDied += OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        _model.PushToInventory(GetRandomMaterial());
    }

    private MaterialsData.Material GetRandomMaterial()
    {
        var materialsSequence = _view.Materials.Sequence;
        var materialIndex = Random.Range(0, materialsSequence.Count);
        
        return materialsSequence[materialIndex] as MaterialsData.Material;
    }

    public void Disable()
    {
        _enemyFactory.EnemyDied -= OnEnemyDied;
    }
}