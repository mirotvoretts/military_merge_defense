using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceActions : MonoBehaviour
{
    [SerializeField] BoolButton buildButton;
    //[SerializeField] BoolButton mergeButton;
    [SerializeField] BoolButton destroyButton;

    private TowerPlace _currentPlace;
    
    private void Start()
    {
        foreach(TowerPlace towerPlace in TowersContainer.towerPlaces)
        {
            towerPlace.OnClicked += SelectPlace;
        }
        buildButton.OnClicked.AddListener(BuildTower);
        destroyButton.OnClicked.AddListener(DestroyTower);
    }

    private void SelectPlace(IClickable clickable)
    {
        if(clickable is TowerPlace towerPlace)
        {
            _currentPlace = towerPlace;
            bool hasTower = towerPlace.Tower != null;
            buildButton.IsUsable = !hasTower;
            //mergeButton.IsUsable = !hasTower;
            destroyButton.IsUsable = hasTower;
        }
        Debug.Log(buildButton.IsUsable);
    }

    private void UpdateButtons()
    {

    }

    private void BuildTower()
    {
        if (buildButton.IsUsable)
        {
            _currentPlace.BuildTower();
            buildButton.IsUsable = false;
            destroyButton.IsUsable = true;
        }
    }

    private void DestroyTower()
    {
        if (destroyButton.IsUsable)
        {
            _currentPlace.DestroyTower();
            destroyButton.IsUsable = false;
            buildButton.IsUsable = true;
        }
    }
}
