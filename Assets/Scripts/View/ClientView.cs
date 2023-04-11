using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClientView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ProductsData _productsData;
    [SerializeField] private Transform _shop;
    [SerializeField] private TextMeshProUGUI _requestedProductLabel;
    [SerializeField] private ClientInfoUIView _infoMenu;

    public ClientPresenter Presenter { get; private set; }
    
    public void OnProductReceived() => Presenter.InvokeOnProductReceived();
    public Transform Shop => _shop;

    private void Awake()
    {
        Presenter = new ClientPresenter(this, _shop, _productsData);
        Presenter.Enable();

        UpdateInfo();
    }

    private void Update()
    {
        if (!Presenter.FinishedMoving) Presenter.MoveToEndOfQueue();
        if (Presenter.ProductReceived) Presenter.MoveOutOfQueue();
    }
    
    private void UpdateInfo()
    {
        _requestedProductLabel.text = Presenter.RequestedProduct.Name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == Config.Mouse1Id && Presenter.FinishedMoving && this == QueueOfClients.Peek())
            _infoMenu.Show();
    }

    private void OnDestroy()
    {
        Presenter.Disable();
    }
}