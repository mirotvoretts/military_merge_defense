using System;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoUIView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    
    public void Show()
    {
        ResetButtonWith(_closeButton, OnCloseClick);
        
        gameObject.SetActive(true);
    }

    private void ResetButtonWith(Button button, Action newListener)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => newListener());
    }

    private void OnCloseClick()
    {
        gameObject.SetActive(false);
    }
}