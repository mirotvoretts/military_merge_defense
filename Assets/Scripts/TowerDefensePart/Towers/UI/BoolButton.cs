using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BoolButton : MonoBehaviour
{
    [SerializeField] private Image _statusImage;
    [SerializeField] private Sprite _activePicture, _disablePicture;

    private Button _button;
    private bool _isUsable = false;

    public Action OnValueSet;
    public Button.ButtonClickedEvent OnClicked;

    public bool IsUsable
    { 
        get => _isUsable;
        set
        {
            _isUsable = value;
            OnValueSet?.Invoke();
        }
    }

    public void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick = OnClicked;
        OnValueSet += UpdateImage;
    }

    public void UpdateImage()
    {
        _statusImage.sprite = _isUsable ? _activePicture : _disablePicture;
    }
}
