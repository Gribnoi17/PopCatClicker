using Assets.Scripts;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreTextMoneyShop;
    [SerializeField] private TextMeshProUGUI _costBonusShop;
    [SerializeField] private TextMeshProUGUI _levelTextShop;
    [SerializeField] private TextMeshProUGUI _clickPowerTextShop;
    [SerializeField] private TextMeshProUGUI _clickPowerNow;

    private void Start()
    {
        EventManager.Clicked += ScoreUpdateCkick;
        EventManager.Bought += UpdateUIIWhenBuy;
        EventManager.OpenedShop += ScoreUpdateClickInShop;
        Wallet.OnWalletInitialized += ScoreUpdateCkick;
        Shop.OnShopInitialized += UpdateUIIWhenBuy;
        
    }

    private void ScoreUpdateCkick()
    {
        _scoreText.text = "ћ€у: " + Wallet.Money;
    }

    private void ScoreUpdateClickInShop()
    {
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;
        _clickPowerNow.text = "—ила м€у: " + Shop.ClickPowerBonus;
    }

    private void UpdateUIIWhenBuy()
    {
        _scoreText.text = "ћ€у: " + Wallet.Money;
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;
        _costBonusShop.text = "÷ена:" + Shop.CostBonus;
        _levelTextShop.text = "”ровень: " + Shop.LevelBonus;
        _clickPowerTextShop.text = "ћ€у коинс + " + Shop.ClickPowerBonus + 5;
        _clickPowerNow.text = "—ила м€у: " + Shop.ClickPowerBonus;
    }

    private void OnDestroy()
    {
        EventManager.Clicked -= ScoreUpdateCkick;
        EventManager.Bought -= UpdateUIIWhenBuy;
        Wallet.OnWalletInitialized -= ScoreUpdateCkick;
        Shop.OnShopInitialized -= UpdateUIIWhenBuy;
        EventManager.OpenedShop -= ScoreUpdateClickInShop;
    }

}
