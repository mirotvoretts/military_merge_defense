using System.Linq;
using TMPro;
using UnityEngine;

public class PlaceActions : MonoBehaviour
{
    [SerializeField] private MergeSystem _mergeSystem;
    [SerializeField] private BoolButton _buildButton;
    [SerializeField] private BoolButton _mergeButton;
    [SerializeField] private BoolButton _destroyButton;

    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private int _priceByLevel;

    private int _price;
    private void SetNewPrice()
    {
        _price = MergeSystem.towerPlaces.Where(x => x.Tower != null).Select(x => (int)x.Tower.Level * _priceByLevel).Sum();
        _priceText.text = _price.ToString();
    }

    private TowerPlace _currentPlace;
    
    private void Start()
    {
        foreach(TowerPlace towerPlace in MergeSystem.towerPlaces)
        {
            towerPlace.OnClicked += SelectPlace;
        }
        SetNewPrice();
        _buildButton.OnClicked.AddListener(BuildTower);
        _mergeButton.OnClicked.AddListener(MergeTower);
        _destroyButton.OnClicked.AddListener(DestroyTower);

        Score.ValueChanged += () =>
        {
            if (_currentPlace != null)
            {
                bool hasTower = _currentPlace.Tower != null;
                _buildButton.IsUsable = hasTower && Score.BuyAvailable(_price);
            }
        };
    }

    private void SelectPlace(IClickable clickable)
    {
        if(clickable is TowerPlace towerPlace)
        {
            DisableSelection();
            _currentPlace = towerPlace;

            _currentPlace.GetComponent<SpriteRenderer>().color = new Color(0, 0.8f, 0);
            bool hasTower = towerPlace.Tower != null;
            _buildButton.IsUsable = !hasTower && Score.BuyAvailable(_price);
            _mergeButton.IsUsable = _mergeSystem.CheckMergeAbility(_currentPlace);
            _destroyButton.IsUsable = hasTower;
        }
    }

    public void DisableSelection()
    {
        if (_currentPlace != null)
        {
            _currentPlace.GetComponent<SpriteRenderer>().color = Color.white;
            _currentPlace = null;
            _buildButton.IsUsable = false;
            _destroyButton.IsUsable = false;
            _mergeButton.IsUsable = false;
        }
    }

    private void BuildTower()
    {
        if (_buildButton.IsUsable && Score.TryBuy(_price))
        {
            _currentPlace.BuildTower();
            _buildButton.IsUsable = false;
            _destroyButton.IsUsable = true;
            _mergeButton.IsUsable = _mergeSystem.CheckMergeAbility(_currentPlace);
            SetNewPrice();
        }
    }

    private void DestroyTower()
    {
        if (_destroyButton.IsUsable)
        {
            _currentPlace.DestroyTower();
            _destroyButton.IsUsable = false;
            _buildButton.IsUsable = true;
            _mergeButton.IsUsable = _mergeSystem.CheckMergeAbility(_currentPlace);
            SetNewPrice();
        }
    }

    private void MergeTower()
    {
        if (_mergeButton.IsUsable)
        {
            _mergeSystem.TryMerge(_currentPlace);
            _mergeButton.IsUsable = _mergeSystem.CheckMergeAbility(_currentPlace);
            SetNewPrice();
        }
    }
}
