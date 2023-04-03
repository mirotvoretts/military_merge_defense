using UnityEngine;

public abstract class Transformable
{
    protected Transform Transform { get; }

    protected Transformable(Transform transform)
    {
        Transform = transform;
    }
    
    public virtual void Start(float deltaTime) { }
    
    public virtual void Update(float deltaTime) { }
}