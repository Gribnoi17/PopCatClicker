using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractor : Interactor
{
    private ShopRepository _repository;

    public int CostBonus => _repository.CostBonus;
    public int LevelBonus => _repository.LevelBonus;
    public int ClickPowerBonus => _repository.ClickPowerBonus;
    public int CostSkin => _repository.CostSkin;

    public ShopInteractor(ShopRepository repository)
    {
        _repository = repository;
    }

    public override void Initialize()
    {
        Shop.Initialize(this);
    }


    public void BuyBonus(int value)
    {
        if (_repository.CostBonus <= value)
        {
            Wallet.SpendMoney(Shop.CostBonus);

            if (_repository.CostBonus > 10000)
                _repository.CostBonus += 5500;
            else
                _repository.CostBonus *= 2;

            _repository.ClickPowerBonus += 5;
            _repository.LevelBonus++;
            _repository.Save();
        }

    }

    public void BuySkin(int value)
    {
        if (_repository.CostSkin <= value)
        {
            Wallet.SpendMoney(Shop.CostSkin);
            _repository.CostSkin = 0;
            _repository.Save();
            EventManager.OnBoughtSkin();
        }

    }

    public void Reset()
    {
        _repository.CostBonus = 20;
        _repository.LevelBonus = 0;
        _repository.ClickPowerBonus = 1;
        _repository.CostSkin = 1000000;
        Wallet.SpendMoney(10000000);
        _repository.Save();
    }

}
