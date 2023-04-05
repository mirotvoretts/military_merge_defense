using TMPro;
using UnityEngine;

public class ClientView : MonoBehaviour
{
    [SerializeField] private Transform _shop;
    
    public TextMeshProUGUI RequestedResourceLabel;

    private ClientPresenter _presenter;

    private void Awake()
    {
        _presenter = new ClientPresenter(this, _shop);
        _presenter.Enable();
    }

    private void Update()
    {
        if (_presenter.QueueHasStopped) return;
        
        _presenter.MoveToEndOfQueue();
    }

    private void OnDestroy()
    {
        _presenter.Disable();
    }
}