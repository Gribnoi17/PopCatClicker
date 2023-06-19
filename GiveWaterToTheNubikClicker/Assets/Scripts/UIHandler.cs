using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreTextMoneyShop;
    [SerializeField] private TextMeshProUGUI _costBonusShop;
    [SerializeField] private TextMeshProUGUI _levelTextShop;
    [SerializeField] private TextMeshProUGUI _clickPowerTextShop;
    [SerializeField] private TextMeshProUGUI _clickPowerNow;
    [SerializeField] private TextMeshProUGUI _costSkin;
    [SerializeField] private Button _catButton;

    [SerializeField] private TextMeshProUGUI _scoreTextPC;
    [SerializeField] private TextMeshProUGUI _scoreTextMoneyShopPC;
    [SerializeField] private TextMeshProUGUI _costBonusShopPC;
    [SerializeField] private TextMeshProUGUI _levelTextShopPC;
    [SerializeField] private TextMeshProUGUI _clickPowerTextShopPC;
    [SerializeField] private TextMeshProUGUI _clickPowerNowPC;
    [SerializeField] private TextMeshProUGUI _costSkinPC;
    [SerializeField] private Button _catButtonPC;
    private SpriteState _spriteState;

    private void Start()
    {
        EventManager.Clicked += ScoreUpdateCkick;
        EventManager.Bought += UpdateUIIWhenBuy;
        EventManager.Bought += RewardUpdate;
        EventManager.OpenedShop += ScoreUpdateClickInShop;
        EventManager.BoughtSkin += ChangeSkin;
        Wallet.OnWalletInitialized += ScoreUpdateCkick;
        Wallet.OnWalletInitialized += UpdateUIIWhenBuyWallet;
        Shop.OnShopInitialized += UpdateUIIWhenBuyShop;    
    }

    private void ScoreUpdateCkick()
    {
        _scoreText.text = "ћ€у: " + Wallet.Money;
        _scoreTextPC.text = "ћ€у: " + Wallet.Money;
    }

    public void ChangeSkin()
    {
        _catButton.image.sprite = Shop.skins[0];
        _spriteState.pressedSprite = Shop.skins[1];
        _catButton.spriteState = _spriteState;
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;
        _scoreText.text = "ћ€у: " + Wallet.Money;
        _costSkin.text = " уплено!";

        _catButtonPC.image.sprite = Shop.skins[0];
        _spriteState.pressedSprite = Shop.skins[1];
        _catButtonPC.spriteState = _spriteState;
        _scoreTextMoneyShopPC.text = "ћ€у коинс: " + Wallet.Money;
        _scoreTextPC.text = "ћ€у: " + Wallet.Money;
        _costSkinPC.text = " уплено!";
    }

    private void ScoreUpdateClickInShop()
    {
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;
        _clickPowerNow.text = "—ила м€у: " + Shop.ClickPowerBonus;

        _scoreTextMoneyShopPC.text = "ћ€у коинс: " + Wallet.Money;
        _clickPowerNowPC.text = "—ила м€у: " + Shop.ClickPowerBonus;
    }

    private void RewardUpdate()
    {
        _scoreText.text = "ћ€у: " + Wallet.Money;
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;

        _scoreTextPC.text = "ћ€у: " + Wallet.Money;
        _scoreTextMoneyShopPC.text = "ћ€у коинс: " + Wallet.Money;
    }

    private void UpdateUIIWhenBuy()
    {
        _costSkin.text = "÷ена: " + Shop.CostSkin.ToString();
        _scoreText.text = "ћ€у: " + Wallet.Money;
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;
        _costBonusShop.text = "÷ена:" + Shop.CostBonus;
        _levelTextShop.text = "”ровень: " + Shop.LevelBonus;
        _clickPowerTextShop.text = "ћ€у коинс + " + 5;
        _clickPowerNow.text = "—ила м€у: " + Shop.ClickPowerBonus;

        _costSkinPC.text = "÷ена: " + Shop.CostSkin.ToString();
        _scoreTextPC.text = "ћ€у: " + Wallet.Money;
        _scoreTextMoneyShopPC.text = "ћ€у коинс: " + Wallet.Money;
        _costBonusShopPC.text = "÷ена:" + Shop.CostBonus;
        _levelTextShopPC.text = "”ровень: " + Shop.LevelBonus;
        _clickPowerTextShopPC.text = "ћ€у коинс + " + 5;
        _clickPowerNowPC.text = "—ила м€у: " + Shop.ClickPowerBonus;
    }

    private void UpdateUIIWhenBuyWallet()
    {
        _scoreText.text = "ћ€у: " + Wallet.Money;
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;

        _scoreTextPC.text = "ћ€у: " + Wallet.Money;
        _scoreTextMoneyShopPC.text = "ћ€у коинс: " + Wallet.Money;

        

    }
    private void UpdateUIIWhenBuyShop()
    {
        _costSkin.text = "÷ена: " + Shop.CostSkin.ToString();
        _costBonusShop.text = "÷ена:" + Shop.CostBonus;
        _levelTextShop.text = "”ровень: " + Shop.LevelBonus;
        _clickPowerNow.text = "—ила м€у: " + Shop.ClickPowerBonus;
        _clickPowerTextShopPC.text = "ћ€у коинс + " + 5;
        _costSkinPC.text = "÷ена: " + Shop.CostSkin.ToString();
        _costBonusShopPC.text = "÷ена:" + Shop.CostBonus;
        _levelTextShopPC.text = "”ровень: " + Shop.LevelBonus;
        _clickPowerNowPC.text = "—ила м€у: " + Shop.ClickPowerBonus;
    }

    private void OnDestroy()
    {
        EventManager.Clicked -= ScoreUpdateCkick;
        EventManager.Bought -= UpdateUIIWhenBuy;
        Wallet.OnWalletInitialized -= ScoreUpdateCkick;
        Shop.OnShopInitialized -= UpdateUIIWhenBuy;
        EventManager.OpenedShop -= ScoreUpdateClickInShop;
        EventManager.BoughtSkin -= ChangeSkin;
        EventManager.Bought -= RewardUpdate;
        Wallet.OnWalletInitialized -= UpdateUIIWhenBuy;
        Wallet.OnWalletInitialized -= UpdateUIIWhenBuyWallet;
        Shop.OnShopInitialized -= UpdateUIIWhenBuyShop;
    }

}
