using UnityEngine;
using UnityEngine.EventSystems;

public class ClientView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ProductsData _productsData;
    [SerializeField] private Transform _shop;
    [SerializeField] private ClientInfoUIView _infoMenu;

    public ClientPresenter Presenter { get; private set; }
    
    public void OnProductReceived() => Presenter.InvokeOnProductReceived();
    public Transform Shop => _shop;

    private void Awake()
    {
        Presenter = new ClientPresenter(this, _shop, _productsData);
        Presenter.Enable();
    }

    private void Update()
    {
        if (!Presenter.FinishedMoving) Presenter.MoveToEndOfQueue();
        if (Presenter.ProductReceived) Presenter.MoveOutOfQueue();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == Config.Mouse1Id && Presenter.FinishedMoving && IsFirstInQueue())
        {
            if (_infoMenu.gameObject.activeSelf)
                _infoMenu.Close();
            else
                _infoMenu.Show();
        }
    }

    private bool IsFirstInQueue()
    {
        return this == QueueOfClients.Peek();
    }

    private void OnDestroy()
    {
        Presenter.Disable();
    }
}