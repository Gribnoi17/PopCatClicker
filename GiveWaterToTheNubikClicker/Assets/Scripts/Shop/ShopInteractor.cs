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
            _repository.CostBonus *= 5;
            _repository.LevelBonus++;
            _repository.ClickPowerBonus += 3;
            _repository.Save();
        }

    }

    public void BuySkin(int value)
    {
        if (_repository.CostBonus <= value)
        {
            Wallet.SpendMoney(Shop.CostBonus);
            _repository.Save();
        }

    }

    public void Reset()
    {
        _repository.CostBonus = 20;
        _repository.LevelBonus = 0;
        _repository.ClickPowerBonus = 1;
        Wallet.SpendMoney(10000000);
        _repository.Save();
    }

}
