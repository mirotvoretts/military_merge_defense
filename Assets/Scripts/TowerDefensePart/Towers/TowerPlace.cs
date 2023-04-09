using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IClickable
{
    [SerializeField] BaseTower towerPrefab;
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
        _tower = Instantiate(towerPrefab, position: transform.position, Quaternion.Euler(0,0,0));
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
