using System.Collections;
using System.Collections.Generic;
using Save;
using TMPro;
using UnityEngine;

public class GoldView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    // Update is called once per frame
    void Update()
    {
        var saveData = GameManager.GetInstance().SaveManagerInstance.SaveDataInstance;
        _text.text = saveData.GetFlagNum(SaveData.SaveFlag.GOLD)+"G";
    }
}
