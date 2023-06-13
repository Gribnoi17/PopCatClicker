using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Shop
{
    public static event Action OnShopInitialized;
    public static int CostBonus { get { CheckClass(); return _shopInteractor.CostBonus; } }
    public static int LevelBonus { get { CheckClass(); return _shopInteractor.LevelBonus; } }
    public static int ClickPowerBonus { get { CheckClass(); return _shopInteractor.ClickPowerBonus; } }
    public static bool IsInitialized { get; private set; }

    private static ShopInteractor _shopInteractor;

    public static void Initialize(ShopInteractor interactor)
    {
        _shopInteractor = interactor;
        IsInitialized = true;
        OnShopInitialized?.Invoke();
    }

    public static void BuyBonus(int valueMoney)
    {
        CheckClass();
        _shopInteractor.BuyBonus(valueMoney);
    }

    public static void BuySkin(int valueMoney)
    {
        CheckClass();
        _shopInteractor.BuySkin(valueMoney);
    }


    private static void CheckClass()
    {
        if (!IsInitialized)
        {
            throw new Exception("Shop is not initialize yet");
        }
    }

}

