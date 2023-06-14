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
    private SpriteState _spriteState;

    private void Start()
    {
        EventManager.Clicked += ScoreUpdateCkick;
        EventManager.Bought += UpdateUIIWhenBuy;
        EventManager.Bought += RewardUpdate;
        EventManager.OpenedShop += ScoreUpdateClickInShop;
        EventManager.BoughtSkin += ChangeSkin;
        Wallet.OnWalletInitialized += ScoreUpdateCkick;
        Shop.OnShopInitialized += UpdateUIIWhenBuy;    
    }

    private void ScoreUpdateCkick()
    {
        _scoreText.text = "ћ€у: " + Wallet.Money;
    }

    public void ChangeSkin()
    {
        _catButton.image.sprite = Shop.skins[0];
        _spriteState.pressedSprite = Shop.skins[1];
        _catButton.spriteState = _spriteState;
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;
        _scoreText.text = "ћ€у: " + Wallet.Money;
        _costSkin.text = " уплено!";
    }

    private void ScoreUpdateClickInShop()
    {
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;
        _clickPowerNow.text = "—ила м€у: " + Shop.ClickPowerBonus;
    }

    private void RewardUpdate()
    {
        _scoreText.text = "ћ€у: " + Wallet.Money;
        _scoreTextMoneyShop.text = "ћ€у коинс: " + Wallet.Money;
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
    }

}
