using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IClickable
{
    [SerializeField] TowerContainer prefabs;
    private BaseTower _tower;
    public BaseTower Tower { get => _tower; }
    public Action<IClickable> OnClicked { get; set; }

    private void Awake()
    {
        MergeSystem.towerPlaces.Add(this);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        OnClicked?.Invoke(this);
    }

    public void BuildTower()
    {
        _tower = Instantiate(prefabs.towers.GetRandomValue(), position: transform.position, Quaternion.Euler(0,0,0));
    }

    public void BuildTower(BaseTower prefab)
    {
        _tower = Instantiate(prefab, position: transform.position, Quaternion.Euler(0,0,0));
    }

    public void DestroyTower()
    {
        Destroy(_tower.gameObject);
        _tower = null;
    }

    public bool CompareByTower(TowerPlace place)
    { 
        return Tower.GetType() == place.Tower.GetType() && (Tower.Level == place.Tower.Level);
    }
}
