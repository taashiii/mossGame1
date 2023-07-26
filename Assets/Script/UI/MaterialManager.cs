using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Save;
using Script.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class MaterialManager : MonoBehaviour
{
    [SerializeField] private MaterialObject _originalObject = null;
    
    protected List<MaterialObject> _materialObjectList = new List<MaterialObject>();

    private int _nowMaterialNum = 0;

    private float _checkInterval = 1;

    private void Update()
    {
        _checkInterval -= Time.deltaTime;
        if (_checkInterval <= 0)
        {
            UpdateMaterialNum();
            var materialNum = GameManager.GetInstance().SaveManagerInstance.SaveDataInstance
                .GetFlagNum(SaveData.SaveFlag.MATERIAL);
            if (_nowMaterialNum < materialNum)
            {
                CreateObject();
            }
            _checkInterval = 2;
        }
    }

    public void FirstCreate()
    {
        var materialNum = GameManager.GetInstance().SaveManagerInstance.SaveDataInstance
            .GetFlagNum(SaveData.SaveFlag.MATERIAL);
        for (int i = 0; i < materialNum; i++)
        {
            CreateObject();
        }
    }
    
    private void CreateObject()
    {
        //activeじゃないオブジェクトがあるなら使いまわす
        var activeObject = _materialObjectList.Find(x => x.gameObject.activeSelf == false);
        if (activeObject != null)
        {
            activeObject.gameObject.SetActive(true);
            return;
        }
        //最大数以上ははじく
        if (_materialObjectList.Count >= GameManager.MAX_NUM)
        {
            return;
        }
        //新規作成
        var objectBase = (MaterialObject)Instantiate(_originalObject, transform, true);
        objectBase.gameObject.SetActive(true);
        var rect = objectBase.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector3(Random.Range(300,-300),Random.Range(500,400),Random.Range(300,-300));

        objectBase.OnClick += () =>
        {
            var saveData = GameManager.GetInstance().SaveManagerInstance.SaveDataInstance;
            //銭が増える
            saveData.AddFlagNum(SaveData.SaveFlag.GOLD,10);
            //素材が減る
            saveData.AddFlagNum(SaveData.SaveFlag.MATERIAL,-1);
        };
        _materialObjectList.Add(objectBase);
    }

    private void UpdateMaterialNum()
    {
        _nowMaterialNum =  _materialObjectList.Count(x => x.gameObject.activeSelf);
    }
    
}
