using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Sprite[] _buttonSprites = null;
    [SerializeField] private Image _targetButton = null;

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

    public void Reward()
    {
        Wallet.AddMoney(500);
        EventManager.OnBought();
    }

}
