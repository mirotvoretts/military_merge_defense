using System;
using System.Collections.Generic;
using System.Linq;

public static class QueueOfClients
{
    private static readonly Queue<Client> Clients = new(Config.MaxQueueOfClientsLength);
    
    public static void Enqueue(Client client)
    {
        Clients.Enqueue(client);
    }

    public static Client Dequeue()
    {
        return Clients.Dequeue();
    }

    public static Client TryBack()
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
}