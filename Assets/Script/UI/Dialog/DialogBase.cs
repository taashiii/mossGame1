using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI.Dialog
{
	/// <summary>
	/// ダイアログ一個単位の挙動
	/// </summary>
	public class DialogBase : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _dialogText;

		[SerializeField] private Button _oneSelectButton;

		public Action OnClose;

		/// <summary>
		/// ダイアログの設定
		/// 表示テキストの設定などを行う
		/// </summary>
		/// <param name="text"></param>
		public void DialogSetting(string text)
		{
			_dialogText.text = text;
			_oneSelectButton.onClick.AddListener(() =>
			{
				Close();
			});
		}

		/// <summary>
		/// 消したときの処理
		/// </summary>
		public void Close()
		{
			OnClose?.Invoke();
			Destroy(gameObject);
		}
	}
}
