using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action Clicked;
    public static event Action MusicChanged;

    public static event Action Bought;
    public static event Action BoughtSkin;
    public static event Action OpenedShop;

    public static void OnClicked()
    {
        Clicked?.Invoke();
    }

    public static void OnBought()
    {
        Bought?.Invoke();
    }
    public static void OnBoughtSkin()
    {
        BoughtSkin?.Invoke();
    }

    public static void OnOpenedShop()
    {
        OpenedShop?.Invoke();
    }
    public static void OnMusicChanged()
    {
        MusicChanged?.Invoke();
    }

}
