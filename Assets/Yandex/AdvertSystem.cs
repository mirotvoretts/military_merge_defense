using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvertSystem : MonoBehaviour
{
    public static Action OnAdvertEnded;
    public static AdvertSystem Instance;

    [SerializeField] private bool _showOnStart = false;

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    private void Start()
    {
        Instance = this;
        if (_showOnStart)
            ShowAdvert();
    }
    public static void ShowAdvert()
    {
        ShowAdv();
    }

    public static void AdvertEnded()
    {
        OnAdvertEnded?.Invoke();
    }

}
