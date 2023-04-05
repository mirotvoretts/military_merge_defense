public interface IClientPresenter
{
    void Enable();
    void Disable();
    bool QueueHasStopped { get;}
}