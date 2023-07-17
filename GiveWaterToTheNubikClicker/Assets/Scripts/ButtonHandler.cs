using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Sprite[] _buttonSprites = null;
    [SerializeField] private Sprite[] _buttonSpritesPC = null;
    [SerializeField] private Image _targetButton = null;
    [SerializeField] private Image _targetButtonPC = null;

    private void OnEnable()
    {
        YandexGame.OpenVideoEvent += Reward;
    }
    private void OnDisable()
    {
        YandexGame.OpenVideoEvent -= Reward;
    }
    public void OpenAndClosePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeInHierarchy);
        EventManager.OnOpenedShop();
    }

    public void ChangeSpriteMusic()
    {
        if (Application.isMobilePlatform == true)
        {
            if (_buttonSprites != null)
            {
                if (_targetButton.sprite == _buttonSprites[0])
                {
                    _targetButton.sprite = _buttonSprites[1];
                    EventManager.OnMusicChanged();
                    return;
                }
                _targetButton.sprite = _buttonSprites[0];
                EventManager.OnMusicChanged();
            }
        }
        else
        {
            if (_buttonSpritesPC != null)
            {
                if (_targetButtonPC.sprite == _buttonSpritesPC[0])
                {
                    _targetButtonPC.sprite = _buttonSpritesPC[1];
                    EventManager.OnMusicChanged();
                    return;
                }
                _targetButtonPC.sprite = _buttonSprites[0];
                EventManager.OnMusicChanged();
            }
        }

    }

    public void Reward()
    {
        Wallet.AddMoney(10000);
        EventManager.OnBought();
    }

}
