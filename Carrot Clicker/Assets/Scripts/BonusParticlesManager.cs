using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusParticlesManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private CarrotManager _carrotManager;
    [SerializeField] private GameObject bonusParticlePrefab;
    private void Awake()
    {
        InputManager.onCarrotClickedPosition += CarrotClickedCallBack;
    }
    private void OnDestroy()
    {
        InputManager.onCarrotClickedPosition -= CarrotClickedCallBack;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CarrotClickedCallBack(Vector2 clickedPosition)
    {
       GameObject bonusParticlesInstance = Instantiate(bonusParticlePrefab,clickedPosition,Quaternion.identity,transform);
        bonusParticlesInstance.GetComponent<BonusParticle>().Configure(_carrotManager.GetCurrentMultiplier());
        Destroy(bonusParticlesInstance, 1f);
    }
}
