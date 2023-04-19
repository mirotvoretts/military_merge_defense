using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionDisabler : MonoBehaviour
{
    [SerializeField] private PlaceActions _placeActions;
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        _placeActions.DisableSelection();
    }
}
