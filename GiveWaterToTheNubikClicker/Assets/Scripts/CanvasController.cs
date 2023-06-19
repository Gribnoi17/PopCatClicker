using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _canvasMobile;
    [SerializeField] private GameObject _canvasDesctop;
    private void Awake()
    {
        if (Application.isMobilePlatform == true)
        {
            _canvasMobile.SetActive(true);
            _canvasDesctop.SetActive(false);
        }
        else
        {
            _canvasDesctop.SetActive(true);
            _canvasMobile.SetActive(false);
        }
    }
}
