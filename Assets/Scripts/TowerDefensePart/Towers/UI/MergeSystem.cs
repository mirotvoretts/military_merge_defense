using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MergeSystem : MonoBehaviour
{
    public static List<TowerPlace> towerPlaces = new List<TowerPlace>();
    [SerializeField] private TowerLevels[] _towerLevels;

    public bool TryMerge(TowerPlace currentPlace)
    {
        foreach(TowerPlace place in towerPlaces)
        {
            if(place == currentPlace || place.Tower == null) 
                continue;

            if (currentPlace.CompareByTower(place))
            {
                MergeTowers(currentPlace, place);
                return true;
            }
        }
        return false;
    }

    public void MergeTowers(TowerPlace currentPlace, TowerPlace secondaryPlace)
    {
        TowerLevels towerLevels = _towerLevels.Where(x => x.towers[0].GetType() == currentPlace.Tower.GetType()).First();
        currentPlace.DestroyTower();
        currentPlace.BuildTower(towerLevels.towers[secondaryPlace.Tower.Level]);
        secondaryPlace.DestroyTower();
    }

    public bool CheckMergeAbility(TowerPlace currentPlace)
    {
        if(currentPlace.Tower == null)
            return false;

        TowerLevels towerLevels = _towerLevels.Where(x => x.towers[0].GetType() == currentPlace.Tower.GetType()).First();
        if(currentPlace.Tower.Level >= towerLevels.towers.Length)
            return false;

        foreach (TowerPlace place in towerPlaces)
        {
            if (place == currentPlace || place.Tower == null)
                continue;

            if (currentPlace.CompareByTower(place))
            {
                return true;
            }
        }

        return false;
    }
}
