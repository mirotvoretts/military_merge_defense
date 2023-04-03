using UnityEngine;

public class ClientsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _client;

    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer();
    }

    private void Update()
    {
        if (QueueOfClients.IsFull()) return;
        
        _timer.Set(Config.ClientsSpawnDelay, SpawnClient);
    }

    private void SpawnClient()
    {
        Instantiate(_client, transform.position, Quaternion.identity);
    }
}
