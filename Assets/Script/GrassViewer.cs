using System.Collections;
using System.Collections.Generic;
using Save;
using UnityEngine;

public class GrassViewer : MonoBehaviour
{
    [SerializeField] private int _value;


    [SerializeField] private GameObject _object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Goldの値の取得

        var saveData = GameManager.GetInstance().SaveManagerInstance.SaveDataInstance;
        int gold = (int)
        saveData.GetFlagNum(SaveData.SaveFlag.GOLD);

        if (gold > _value)
        {
            //お金がValueより多い時
            _object.SetActive(true);
        }
        else {
            _object.SetActive(false);
        }



    }
}
