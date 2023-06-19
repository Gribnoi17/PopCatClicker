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
        _scoreText.text = "���: " + Wallet.Money;
        _scoreTextPC.text = "���: " + Wallet.Money;
    }

    public void ChangeSkin()
    {
        _catButton.image.sprite = Shop.skins[0];
        _spriteState.pressedSprite = Shop.skins[1];
        _catButton.spriteState = _spriteState;
        _scoreTextMoneyShop.text = "��� �����: " + Wallet.Money;
        _scoreText.text = "���: " + Wallet.Money;
        _costSkin.text = "�������!";

        _catButtonPC.image.sprite = Shop.skins[0];
        _spriteState.pressedSprite = Shop.skins[1];
        _catButtonPC.spriteState = _spriteState;
        _scoreTextMoneyShopPC.text = "��� �����: " + Wallet.Money;
        _scoreTextPC.text = "���: " + Wallet.Money;
        _costSkinPC.text = "�������!";
    }

    private void ScoreUpdateClickInShop()
    {
        _scoreTextMoneyShop.text = "��� �����: " + Wallet.Money;
        _clickPowerNow.text = "���� ���: " + Shop.ClickPowerBonus;

        _scoreTextMoneyShopPC.text = "��� �����: " + Wallet.Money;
        _clickPowerNowPC.text = "���� ���: " + Shop.ClickPowerBonus;
    }

    private void RewardUpdate()
    {
        _scoreText.text = "���: " + Wallet.Money;
        _scoreTextMoneyShop.text = "��� �����: " + Wallet.Money;

        _scoreTextPC.text = "���: " + Wallet.Money;
        _scoreTextMoneyShopPC.text = "��� �����: " + Wallet.Money;
    }

    private void UpdateUIIWhenBuy()
    {
        _costSkin.text = "����: " + Shop.CostSkin.ToString();
        _scoreText.text = "���: " + Wallet.Money;
        _scoreTextMoneyShop.text = "��� �����: " + Wallet.Money;
        _costBonusShop.text = "����:" + Shop.CostBonus;
        _levelTextShop.text = "�������: " + Shop.LevelBonus;
        _clickPowerTextShop.text = "��� ����� + " + 5;
        _clickPowerNow.text = "���� ���: " + Shop.ClickPowerBonus;

        _costSkinPC.text = "����: " + Shop.CostSkin.ToString();
        _scoreTextPC.text = "���: " + Wallet.Money;
        _scoreTextMoneyShopPC.text = "��� �����: " + Wallet.Money;
        _costBonusShopPC.text = "����:" + Shop.CostBonus;
        _levelTextShopPC.text = "�������: " + Shop.LevelBonus;
        _clickPowerTextShopPC.text = "��� ����� + " + 5;
        _clickPowerNowPC.text = "���� ���: " + Shop.ClickPowerBonus;
    }

    private void UpdateUIIWhenBuyWallet()
    {
        _scoreText.text = "���: " + Wallet.Money;
        _scoreTextMoneyShop.text = "��� �����: " + Wallet.Money;

        _scoreTextPC.text = "���: " + Wallet.Money;
        _scoreTextMoneyShopPC.text = "��� �����: " + Wallet.Money;

        

    }
    private void UpdateUIIWhenBuyShop()
    {
        _costSkin.text = "����: " + Shop.CostSkin.ToString();
        _costBonusShop.text = "����:" + Shop.CostBonus;
        _levelTextShop.text = "�������: " + Shop.LevelBonus;
        _clickPowerNow.text = "���� ���: " + Shop.ClickPowerBonus;
        _clickPowerTextShopPC.text = "��� ����� + " + 5;
        _costSkinPC.text = "����: " + Shop.CostSkin.ToString();
        _costBonusShopPC.text = "����:" + Shop.CostBonus;
        _levelTextShopPC.text = "�������: " + Shop.LevelBonus;
        _clickPowerNowPC.text = "���� ���: " + Shop.ClickPowerBonus;
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
