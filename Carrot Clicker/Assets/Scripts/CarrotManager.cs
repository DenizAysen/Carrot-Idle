using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarrotManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private double totalCarrotsCount;
    [SerializeField] private int carrotIncrementValue;

    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI carrotText;
    private void Awake()
    {
        LoadData();

        InputManager.onCarrotClicked += CarrotClickedCallBack;
    }
    void Start()
    {
        
    }
    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallBack;
    }
    private void CarrotClickedCallBack()
    {
        totalCarrotsCount += carrotIncrementValue;

        UpdateCarrotText();

        SaveData();
    }
    private void UpdateCarrotText()
    {
        carrotText.text = totalCarrotsCount + " " + "Carrots!";
    }
    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotsCount.ToString());
    }
    private void LoadData()
    {
       double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotsCount);

       UpdateCarrotText();
    }
}
