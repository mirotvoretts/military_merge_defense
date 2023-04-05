using UnityEngine;

public class ClientPresenter
{
    private readonly Client _model;
    private readonly ClientView _view;
    private readonly Transform _shop;
    
    private ClientView _localLastClientInQueue;

    public bool QueueHasStopped { get; private set; }
    
    private void OnReachedEndOfQueue() => QueueHasStopped = true;
    private void OnQueueStartedMoving() => QueueHasStopped = false;

    public ClientPresenter(ClientView view, Transform shop)
    {
        _model = new Client();
        _view = view;
        _shop = shop;
    }

    public void Enable()
    {
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
        
        TryLeaveQueue();
    }
}