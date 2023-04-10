using System.Collections.Generic;
using UnityEngine;

public class ShopPresenter : IPresenter
{
    private readonly Shop _model;
    private readonly ShopView _view;
    
    private readonly EnemyFactory _enemyFactory;
    
    public List<Materials.Material> Inventory() => _model.Inventory;
    
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

    private Materials.Material GetRandomMaterial()
    {
        var materialIndex = Random.Range(0, Materials.Sequence.Count);
        
        return Materials.Sequence[materialIndex];
    }

    public void Disable()
    {
        _enemyFactory.EnemyDied -= OnEnemyDied;
    }
}