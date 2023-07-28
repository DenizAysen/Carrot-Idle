using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarrotManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private double totalCarrotsCount; 
    [SerializeField] private int frenzyModeMultiplier;
    private int carrotIncrementValue;

    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI carrotText;
    private void Awake()
    {
        LoadData();

        carrotIncrementValue = 1;

        InputManager.onCarrotClicked += CarrotClickedCallBack;

        Carrot.onFrenzyModeStarted += FrenzyModeStartedCallBack;
        Carrot.onFrenzyModeEnded += FrenzyModeEndedCallBack;
    }
    void Start()
    {
        
    }
    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallBack;

        Carrot.onFrenzyModeStarted -= FrenzyModeStartedCallBack;
        Carrot.onFrenzyModeEnded -= FrenzyModeEndedCallBack;
    }
    #region CallBacks
    private void CarrotClickedCallBack()
    {
        totalCarrotsCount += carrotIncrementValue;

        UpdateCarrotText();

        SaveData();
    }
    private void FrenzyModeStartedCallBack()
    {
        carrotIncrementValue = frenzyModeMultiplier;
    }
    private void FrenzyModeEndedCallBack()
    {
        carrotIncrementValue = 1;
    }
    #endregion
    private void UpdateCarrotText()
    {
        carrotText.text = totalCarrotsCount + " " + "Carrots!";
    }

    public int GetCurrentMultiplier()
    {
        return carrotIncrementValue;
    }
    #region Data
    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotsCount.ToString());
    }
    private void LoadData()
    {
       double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotsCount);

       UpdateCarrotText();
    }
    #endregion
}
