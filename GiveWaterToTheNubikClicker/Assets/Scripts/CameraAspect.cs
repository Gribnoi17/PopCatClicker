using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _aspect;


    // Update is called once per frame
    void Update()
    {
        float width = Screen.height * _aspect;
        float w = width / Screen.width;
        float x = (1 - w) / 2f;
        _camera.rect = new Rect(x, 0, w, 0);
    }
}
