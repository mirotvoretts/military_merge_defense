using UnityEngine;

public class ClientPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _shop;

    private Client _model;
    private bool _movementIsFinished;
        
    private void Awake()
    {
        _model = new Client(transform, _shop.transform);
        
        _model.ReachedEndOfQueue += FinishMovement;
    }

    private void Update()
    {
        if (_movementIsFinished) return;
        
        _model.Update(Time.deltaTime);
    }

    private void FinishMovement() => _movementIsFinished = true;
}
