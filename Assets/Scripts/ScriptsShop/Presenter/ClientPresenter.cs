using UnityEngine;

public class ClientPresenter : IPresenter
{
    private readonly Client _model;
    private readonly ClientView _view;
    private readonly Transform _shop;
    private readonly Shop _shopModel;

    private ClientView _localLastClientInQueue;

    public bool FinishedMoving { get; private set; }
    public bool ProductReceived { get; private set; }
    
    private void OnReachedEndOfQueue() => FinishedMoving = true;
    private void OnQueueStartedMoving() => FinishedMoving = false;
    private void OnProductReceived() => ProductReceived = true;
    
    public Product RequestedProduct => _model.RequestedProduct;
    
    public void InvokeOnProductReceived() => _model.InvokeOnProductReceived();

    public ClientPresenter(ClientView view, Transform shop, ProductsData productsData)
    {
        _model = new Client(productsData);
        _view = view;
        _shop = shop;
    }

    public void Enable()
    {
        _model.ProductReceived += OnProductReceived;
        _model.ReachedEndOfQueue += OnReachedEndOfQueue;
        QueueOfClients.StartedMoving += OnQueueStartedMoving;

        _localLastClientInQueue = QueueOfClients.TryBack();
        
        QueueUp();
    }

    private void QueueUp()
    {
        QueueOfClients.Enqueue(_view);
    }

    private void TryLeaveQueue()
    {
        if (QueueOfClients.Peek() == _view)
            QueueOfClients.Dequeue();
    }
    
    public void MoveToEndOfQueue()
    {
        if (_localLastClientInQueue != null && _localLastClientInQueue.Presenter.ProductReceived)
            _localLastClientInQueue = null;
            
        var targetPosition = _localLastClientInQueue == null ? ShopView.Instance.transform.position : _localLastClientInQueue.transform.position;

        if (_view.transform.position.y < targetPosition.y - 2f)
            _view.transform.Translate(Vector3.up * Config.ClientSpeed * Time.deltaTime);
    }

    public void MoveOutOfQueue()
    {
        if (_view.transform.position.y >= _shop.position.y - 2f)
        {
            TryLeaveQueue();
            _view.transform.Translate(Vector3.left * Config.ClientSpeed * Time.deltaTime);
        }
    }

    public void Disable()
    {
        _model.ProductReceived -= OnProductReceived;
        _model.ReachedEndOfQueue -= OnReachedEndOfQueue;
        QueueOfClients.StartedMoving -= OnQueueStartedMoving;
    }
}