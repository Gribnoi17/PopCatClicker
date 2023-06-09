using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> _skins;
    private ShopRepository _shopRepository;
    private ShopInteractor _shopInteractor;

    private void Start()
    {
        _shopRepository = new ShopRepository();
        _shopRepository.Initialize();

        _shopInteractor = new ShopInteractor(_shopRepository);
        _shopInteractor.Initialize();

        Shop.skins = _skins;
        //_shopInteractor.Reset();
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
    }
}
