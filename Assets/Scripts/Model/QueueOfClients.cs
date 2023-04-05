using System;
using System.Collections.Generic;
using System.Linq;

public static class QueueOfClients
{
    private static readonly Queue<ClientView> Clients = new(Config.MaxQueueOfClientsLength);
    
    public static event Action StartedMoving;
    
    public static void Enqueue(ClientView client)
    {
        Clients.Enqueue(client);
    }

    public static ClientView Dequeue()
    {
        StartedMoving?.Invoke();
        return Clients.Dequeue();
    }

    public static ClientView TryBack()
    {
        try
        {
            return Clients.Last();
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public static bool IsFull()
    {
        return Clients.Count >= Config.MaxQueueOfClientsLength;
    }

    public static ClientView Peek()
    {
        return Clients.Peek();
    }
}