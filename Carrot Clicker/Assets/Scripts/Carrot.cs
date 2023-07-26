using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform carrotRendererTransform;
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
        carrotRendererTransform.localScale = Vector3.one * .8f;
        LeanTween.cancel(carrotRendererTransform.gameObject);
        LeanTween.scale(carrotRendererTransform.gameObject, Vector3.one*.7f, .15f).setLoopPingPong(1);
    }
}
