using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceActions : MonoBehaviour
{
    [SerializeField] private MergeSystem _mergeSystem;
    [SerializeField] private BoolButton _buildButton;
    [SerializeField] private BoolButton _mergeButton;
    [SerializeField] private BoolButton _destroyButton;

    private TowerPlace _currentPlace;
    
    private void Start()
    {
        foreach(TowerPlace towerPlace in MergeSystem.towerPlaces)
        {
            towerPlace.OnClicked += SelectPlace;
        }
        _buildButton.OnClicked.AddListener(BuildTower);
        _mergeButton.OnClicked.AddListener(MergeTower);
        _destroyButton.OnClicked.AddListener(DestroyTower);
    }

    private void SelectPlace(IClickable clickable)
    {
        if(clickable is TowerPlace towerPlace)
        {
            _currentPlace = towerPlace;
            bool hasTower = towerPlace.Tower != null;
            _buildButton.IsUsable = !hasTower;
            _mergeButton.IsUsable = _mergeSystem.CheckMergeAbility(_currentPlace);
            _destroyButton.IsUsable = hasTower;
        }
    }

    private void BuildTower()
    {
        if (_buildButton.IsUsable)
        {
            _currentPlace.BuildTower();
            _buildButton.IsUsable = false;
            _destroyButton.IsUsable = true;
            _mergeButton.IsUsable = _mergeSystem.CheckMergeAbility(_currentPlace);
        }
    }

    private void DestroyTower()
    {
        if (_destroyButton.IsUsable)
        {
            _currentPlace.DestroyTower();
            _destroyButton.IsUsable = false;
            _buildButton.IsUsable = true;
        }
    }

    private void MergeTower()
    {
        if (_mergeButton.IsUsable)
        {
            _mergeSystem.TryMerge(_currentPlace);
            _mergeButton.IsUsable = _mergeSystem.CheckMergeAbility(_currentPlace);
        }
    }
}
