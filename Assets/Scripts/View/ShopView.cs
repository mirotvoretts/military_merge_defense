using UnityEngine;
using UnityEngine.EventSystems;

public class ShopView : MonoBehaviour, IPointerClickHandler
{
    private ShopPresenter _presenter;
    
    private void Awake()
    {
        _presenter = new ShopPresenter(this);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            Debug.Log("Inventory Opened");
        }
    }
}