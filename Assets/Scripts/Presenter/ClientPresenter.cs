using UnityEngine;

public class ClientPresenter : IPresenter
{
    private readonly Client _model;
    private readonly ClientView _view;
    private readonly Transform _shop;
    private readonly Shop _shopModel;

    private ClientView _localLastClientInQueue;

    public bool QueueHasStopped { get; private set; }
    
    private void OnReachedEndOfQueue() => QueueHasStopped = true;
    private void OnQueueStartedMoving() => QueueHasStopped = false;
    
    public ProductsData.Product GetRequestedProduct() => _model.RequestedProduct;

    public ClientPresenter(ClientView view, Transform shop, ProductsData productsData)
    {
        _model = new Client(productsData);
        _view = view;
        _shop = shop;
    }

    public void Enable()
    {
        _model.ReachedEndOfQueue += OnReachedEndOfQueue;
        QueueOfClients.StartedMoving += OnQueueStartedMoving;
        //_shopModel.GaveClientProduct += TryLeaveQueue;

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
        var targetPosition = _localLastClientInQueue == null ? _shop.position : _localLastClientInQueue.transform.position;

        if (_view.transform.position.y <= targetPosition.y - 1.5f)
            _view.transform.Translate(Vector3.up * Config.ClientSpeed * Time.deltaTime);
        else
            _model.InvokeOnReachedEndOfQueue();
    }

    public void Disable()
    {
        _model.ReachedEndOfQueue -= OnReachedEndOfQueue;
        QueueOfClients.StartedMoving -= OnQueueStartedMoving;
        //_shopModel.GaveClientProduct -= TryLeaveQueue;
    }
}