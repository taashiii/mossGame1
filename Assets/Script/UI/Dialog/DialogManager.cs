using UnityEngine;
using System.Collections.Generic;


namespace UI.Dialog
{
	/// <summary>
	/// ダイアログの管理します
	/// </summary>
	public class DialogManager : MonoBehaviour
	{
		private static DialogManager Instance;
		public List<DialogBase> DialogList { get; private set; }
		[SerializeField] private DialogBase OriginalDialogBase;
		void Awake()
		{
			Instance = this;
			DialogList = new List<DialogBase>();
		}

		public static DialogManager GetInstance()
		{
			return Instance;
		}

		/// <summary>
		/// ダイアログを生み出す
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public DialogBase CreateDialog(string text)
		{
			DialogBase dialog = Instantiate(OriginalDialogBase);
			dialog.DialogSetting(text);
			dialog.transform.SetParent(this.transform);
			dialog.transform.transform.localPosition = new Vector3(0, 0, 0);
			dialog.transform.transform.localScale = new Vector3(1, 1, 1);
			dialog.gameObject.SetActive(true);

			DialogList.Add(dialog);

			dialog.OnClose += () =>
			{
				DialogList.Remove(dialog);
			};
			return dialog;
		}

		/// <summary>
		/// すべてのダイアログを消す
		/// </summary>
		public void DialogClear()
		{
			for (int i = 0; i < DialogList.Count; i++)
			{
				DialogList[i].Close();
				DialogList[i] = null;
			}
			DialogList.Clear();
		}

		/// <summary>
		/// ダイアログが一個以上存在しているか
		/// </summary>
		/// <returns></returns>
		public bool IsDialogEnable()
		{
			return DialogList.Count >= 1;
		}
	}
}