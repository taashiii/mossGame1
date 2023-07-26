using System;
using Save;
using Script.UI;
using UnityEngine;

/// <summary>
/// ゲーム全体を管理
/// </summary>
public class GameManager : MonoBehaviour
{
	/// <summary>
	/// セーブデータの管理
	/// </summary>
	public Save.SaveManager SaveManagerInstance;
	private static GameManager _main;
	public const int MAX_NUM = 10;
	public const int MAX_WATER = 100;
	[SerializeField] private MaterialManager _materialManager;

	void Awake()
	{
		_main = this;
		SaveManagerInstance = new Save.SaveManager();

		//ロード
		var isFirst = SaveManagerInstance.LoadOrInitializeReturnInitialize();
		//初回何かしら処理を分けるならisFirstを参照
		if (isFirst)
		{
		}

		UpdateMaterialData();
		_materialManager.FirstCreate();
	}

	void Update()
	{
		UpdateMaterialData();
	}

	private void UpdateMaterialData()
	{
		var saveData = SaveManagerInstance.SaveDataInstance;
		var oldTime = saveData.GetFlagNum(SaveData.SaveFlag.NOW_TIME);
		var timeSpan = new TimeSpan(DateTime.Now.Ticks - oldTime);
		//60秒に一回素材生成とする
		var createNum = timeSpan.TotalSeconds / 60;
		if (createNum >= 1)
		{
			if (createNum >= MAX_NUM)
			{
				createNum = MAX_NUM;
			}
			//時間経過分　素材設置
			saveData.SetFlagNum(SaveData.SaveFlag.MATERIAL,
				(long)createNum + saveData.GetFlagNum(SaveData.SaveFlag.MATERIAL));
			//時間更新
			saveData.SetFlagNum(SaveData.SaveFlag.NOW_TIME,
				DateTime.Now.Ticks);
		}
		//時間経過で水が増える
		 createNum = timeSpan.TotalSeconds / 60;
		if (createNum >= 1)
		{
			if (createNum >= MAX_WATER)
			{
				createNum = MAX_WATER;
			}
			//時間経過分　素材設置
			saveData.SetFlagNum(SaveData.SaveFlag.WATER,(long)createNum);
				
		}

	}
	
	public static GameManager GetInstance()
	{
		return _main;
	}


	/// <summary>
	/// ホームキーを押したときアプリ終了時などはfalseが変える
	/// </summary>
	/// <param name="focus"></param>
	private void OnApplicationFocus(bool focus)
	{
		if(!focus)
		{
            //進行保存
            SaveManagerInstance.Save();
		}
	}
}
