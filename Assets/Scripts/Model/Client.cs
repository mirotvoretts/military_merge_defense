using System;
using UnityEngine;

public class Client : Transformable
{
    private readonly Transform _shop;
    
    public event Action ReachedEndOfQueue;

    public Client(Transform transform, Transform shop) : base(transform)
    {
        _shop = shop;
        ReachedEndOfQueue += QueueUp;
    }

    public override void Update(float deltaTime)
    {
        MoveToEndOfQueue(deltaTime);
    }

    private void QueueUp()
    {
        QueueOfClients.Enqueue(this);
    }

    private void LeaveQueue()
    {
        QueueOfClients.Dequeue();
    }

    private void MoveToEndOfQueue(float deltaTime)
    {
        var lastClientInQueue = QueueOfClients.TryBack();

        var targetPosition = lastClientInQueue == null ? _shop.position : lastClientInQueue.Transform.position;

        if (Transform.position.y <= targetPosition.y - 1.5f)
            Transform.Translate(Vector3.up * Config.ClientSpeed * deltaTime);
        else
            ReachedEndOfQueue?.Invoke();
    }
}
