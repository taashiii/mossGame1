using System;

namespace Save
{
	/// <summary>
	/// セーブデータ バイナリ化するので[System.Serializable]をつけないといけない
	/// </summary>
	[System.Serializable]
	public class SaveData
	{
		public const int MAX_FLAG = 100;
		public const int MAX_ITEM = 5;
		/// <summary>
		/// フラグ
		/// 新規フラグを用意する場合は末尾から追加を推奨します
		/// (すでに作成したScriptableObjectの値がずれるので)
		/// </summary>
		public enum SaveFlag
		{
			GOLD,
			NOW_TIME,
			MATERIAL,
			WATER,
		}

		/// <summary>
		/// 言語種類
		/// </summary>
		public enum LANGUAGE
		{
			JAPAN,
			ENGLISH
		}

		/// <summary>
		/// フラグ格納
		/// </summary>
		private long[] _saveFlagDataList;

		/// <summary>
		/// 現在の言語
		/// </summary>
		private LANGUAGE _language;

		/// <summary>
		/// 初期化
		/// 初回起動時とセーブデータクリアで呼ぶ
		/// </summary>
		public void Init()
		{
			_saveFlagDataList = new long[MAX_FLAG];
SetFlagNum(SaveData.SaveFlag.NOW_TIME,
				DateTime.Now.Ticks);

			SetFlagNum(SaveData.SaveFlag.MATERIAL,
				5);
		}

		public long GetFlagNum(SaveFlag flag)
		{
			return _saveFlagDataList[(int)flag];
		}

		public void SetFlagNum(SaveFlag flag, long value)
		{
			_saveFlagDataList[(int)flag] = value;
		}
		
		public void AddFlagNum(SaveFlag flag, int value)
		{
			_saveFlagDataList[(int)flag] += value;
		}

		public void SetLanguage(LANGUAGE language)
		{
			_language = language;
		}

		public LANGUAGE GetLanguage()
		{
			return _language;
		}

	}
}
