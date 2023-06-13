using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private ShopRepository _shopRepository;
    private ShopInteractor _shopInteractor;

    private void Start()
    {
        _shopRepository = new ShopRepository();
        _shopRepository.Initialize();

        _shopInteractor = new ShopInteractor(_shopRepository);
        _shopInteractor.Initialize();

        //_shopInteractor.Reset();

    }

    public void BuyBonus()
    {
        Shop.BuyBonus(Wallet.Money);
        EventManager.OnBought();
    }
    public void BuySkin()
    {
        Shop.BuySkin(Wallet.Money);
        EventManager.OnBought();
    }
}
