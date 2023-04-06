using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClientView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ProductsData _productsData;
    [SerializeField] private Transform _shop;
    [SerializeField] private TextMeshProUGUI _requestedProductLabel;
    [SerializeField] private ClientInfoUIView _infoMenu;
    
    private ClientPresenter _presenter;

    private void Awake()
    {
        _presenter = new ClientPresenter(this, _shop, _productsData);
        _presenter.Enable();

        UpdateInfo();
    }

    private void Update()
    {
        if (_presenter.QueueHasStopped) return;
        
        _presenter.MoveToEndOfQueue();
    }
    
    private void UpdateInfo()
    {
        _requestedProductLabel.text = _presenter.GetRequestedProduct().Name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
            _infoMenu.Show();
    }

    private void OnDestroy()
    {
        _presenter.Disable();
    }
}