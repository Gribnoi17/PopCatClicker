using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerZone : MonoBehaviour
{
    private WalletRepository _walletRepository;
    private WalletInteractor _walletInteractor;
    private Button _catButton;

    private void Start()
    {
        _walletRepository = new WalletRepository();
        _walletRepository.Initialize();

        _walletInteractor = new WalletInteractor(_walletRepository);
        _walletInteractor.Initialize();

        _catButton = GetComponent<Button>();
    }

    public void OnClick()
    {
        Wallet.AddMoney(Shop.ClickPowerBonus);
        EventManager.OnClicked();
    }
}
