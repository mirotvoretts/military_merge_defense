using UnityEngine;
using UnityEngine.EventSystems;

public class ShopView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EnemyFactory _enemyFactory;
        
    private ShopPresenter _presenter;
    
    private void Awake()
    {
        _presenter = new ShopPresenter(this, _enemyFactory);
        _presenter.Enable();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == Config.Mouse1Id)
        {
            Debug.Log(_presenter.Inventory()[_presenter.Inventory().Count - 1].Name);
        }
    }

    private void OnDestroy()
    {
        _presenter.Disable();
    }
}