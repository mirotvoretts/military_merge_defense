using System;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IClickable
{
    public Action<IClickable> OnClicked { get; set; }
}
