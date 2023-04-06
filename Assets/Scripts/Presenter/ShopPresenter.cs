using UnityEngine;

public class ShopPresenter : IPresenter
{
    private readonly Shop _model;
    private readonly ShopView _view;
    
    private readonly EnemyFactory _enemyFactory;

    public ShopPresenter(ShopView view)
    {
        _model = Shop.GetInstance();
        _view = view;
        _enemyFactory = new EnemyFactory();
    }
    
    public void Enable()
    {
        _enemyFactory.EnemyDied += OnEnemyDied;
    }

    private void GaveClientProduct()
    {
        _model.InvokeOnGaveClientProduct();
    }

    private void OnEnemyDied()
    {
        _model.PushToInventory(GetRandomMaterial());
    }

    private Materials.Material GetRandomMaterial()
    {
        var materialIndex = Random.Range(0, Materials.Sequence.Count - 1);
        
        return Materials.Sequence[materialIndex];
    }

    public void Disable()
    {
        _enemyFactory.EnemyDied -= OnEnemyDied;
    }
}