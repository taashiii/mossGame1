using System;
using Save;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class MaterialObject : MonoBehaviour
    {
        [SerializeField] private Button _button;
        // Start is called before the first frame update
        public Action OnClick;
        void Start()
        {
            _button.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                OnClick();
            });
        }
    }
}
