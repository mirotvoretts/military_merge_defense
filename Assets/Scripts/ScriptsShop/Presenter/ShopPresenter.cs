using System.Collections.Generic;
using UnityEngine;

public class ShopPresenter : IPresenter
{
    private readonly EnemyFactory _enemyFactory;
    private readonly Shop _model;
    private readonly ShopView _view;
    
    public List<Item> Inventory => _model.Inventory;
    
    public ShopPresenter(ShopView view, EnemyFactory enemyFactory)
    {
        _model = Shop.GetInstance();
        _view = view;
        _enemyFactory = enemyFactory;
    }
    
    public void Enable()
    {
        _enemyFactory.OnEnemySpawned += ListenEnemyDeath;
        WaveSystem.OnWaveChanged += GiveRandomMaterial;
    }
    
    private void ListenEnemyDeath(BaseEnemy enemy)
    {
        enemy.OnDied += (enemy) =>
        {
            OnEnemyDied();
        };
    }

    private void OnEnemyDied()
    {
        if(Random.Range(0,100) < 15)
            _model.PushToInventory(GetRandomMaterial());
    }

    private CraftMaterial GetRandomMaterial()
    {
        var materialsSequence = _view.Materials.Sequence;
        var materialIndex = Random.Range(0, materialsSequence.Count);
        
        return materialsSequence[materialIndex] as CraftMaterial;
    }

    public void Disable()
    {
        _enemyFactory.OnEnemySpawned -= ListenEnemyDeath;
    }

    private void GiveRandomMaterial()
    {
        for (int i = 0; i < Random.Range(2, Mathf.Clamp(WaveSystem.Wave, 2, 12)); i++)
        {
            _model.PushToInventory(GetRandomMaterial());
        }
    }
}