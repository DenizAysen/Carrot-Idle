using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Carrot : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform carrotRendererTransform;
    [SerializeField] private Image carrotFillImage;

    [Header("Settings")]
    [SerializeField] private float _fillRate;
    private bool _isFrenzyModeActive;

    [Header("Actions")]
    public static Action onFrenzyModeStarted; 
    public static Action onFrenzyModeEnded;
    private void Awake()
    {
        InputManager.onCarrotClicked += CarrotClickedCallBack;
    }
    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallBack;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CarrotClickedCallBack()
    {
        //Animate Carrot Renderer
        AnimateCarrot();

        // Fill Carrot Image
        if(!_isFrenzyModeActive)
            FillCarrot();
    }
    private void AnimateCarrot()
    {
        carrotRendererTransform.localScale = Vector3.one * .8f;
        LeanTween.cancel(carrotRendererTransform.gameObject);
        LeanTween.scale(carrotRendererTransform.gameObject, Vector3.one * .7f, .15f).setLoopPingPong(1);
    }
    private void FillCarrot()
    {
        carrotFillImage.fillAmount += _fillRate;

        if (carrotFillImage.fillAmount >= 1f)
            StartFrenzyMode();
    }
    private void StartFrenzyMode()
    {
        _isFrenzyModeActive = true;
        LeanTween.value(1, 0, 5f).setOnUpdate((value) => carrotFillImage.fillAmount = value).setOnComplete(StopFrenzyMode);

        onFrenzyModeStarted?.Invoke();
    }
    private void StopFrenzyMode()
    {
        _isFrenzyModeActive = false;

        onFrenzyModeEnded?.Invoke();
    }
}
