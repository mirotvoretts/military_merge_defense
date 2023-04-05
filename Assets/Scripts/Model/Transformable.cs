using UnityEngine;

public abstract class Transformable
{
    protected internal Transform Transform { get; }

    protected Transformable(Transform transform)
    {
        Transform = transform;
    }
    
    public virtual void Start() { }
    
    public virtual void Update(float deltaTime) { }
}