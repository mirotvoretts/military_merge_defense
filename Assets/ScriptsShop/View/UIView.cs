using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIView : MonoBehaviour
{
    public abstract void Show();

    protected void ResetButtonWith(Button button, Action newListener)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => newListener());
    }
}