using UnityEngine;
using DG.Tweening;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _meowText;
    [SerializeField] private Transform _spawnPointTransform;
    [SerializeField] private Transform _movePointTransform;

    private GameObject _meowTextTemp;
    private void Start()
    {
        EventManager.Clicked += InstantiateMeowText;
    }

    private void InstantiateMeowText()
    {
        var randInt = Random.Range(1, 10);
        if (randInt == 3)
        {
            _meowTextTemp = Instantiate(_meowText, _spawnPointTransform.position, Quaternion.identity);
            MoveMeowText();
        }
    }
    private void MoveMeowText()
    {
        _meowTextTemp.transform.DOMove(_movePointTransform.position, 1.2f).SetEase(Ease.Linear);
        _meowTextTemp.transform.DOScale(0, 1.35f).SetEase(Ease.Linear);
        DestroyMeowText();
    }

    private void DestroyMeowText()
    {
        Destroy(_meowTextTemp, 1.6f);
    }

    private void OnDestroy()
    {
        EventManager.Clicked -= InstantiateMeowText;
    }
}
