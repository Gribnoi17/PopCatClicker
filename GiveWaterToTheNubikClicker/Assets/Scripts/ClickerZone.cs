using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ClickerZone : MonoBehaviour
{
    private WalletRepository _walletRepository;
    private WalletInteractor _walletInteractor;

    private void Start()
    {
        _walletRepository = new WalletRepository();
        _walletRepository.Initialize();

        _walletInteractor = new WalletInteractor(_walletRepository);
        _walletInteractor.Initialize();

        StartCoroutine(UpdateLeaderBoard());
    }

    public void OnClick()
    {
        Wallet.AddMoney(Shop.ClickPowerBonus);
        EventManager.OnClicked();
    }

    private IEnumerator UpdateLeaderBoard()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            YandexGame.NewLeaderboardScores("LeaderBoard", Wallet.Money);
        }
    }
}
