using UnityEngine;

public static class ProgrammableInput
{
    private static readonly Camera Camera = Camera.main;
    
    public static bool OnMouseClickObjectWithComponent<T>()
    {
        var ray = Camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.TryGetComponent<T>(out _))
            {
                if (Input.GetMouseButton(0))
                {
                    return true;
                }
            }
        }

        return false;
    }
}