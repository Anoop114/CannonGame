using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UIScripts
{
    public class UIButtonAction : MonoBehaviour
    {
        [Header("sound Btn")]
        [SerializeField] private Button soundBtn;
        [SerializeField] private GameObject closeSoundImage;
        private bool _isSoundBtnClicked;
        private void Start()
        {
            soundBtn.onClick.AddListener(SoundBtnClick);
        }

        private void SoundBtnClick()
        {
            _isSoundBtnClicked = !_isSoundBtnClicked;
            closeSoundImage.SetActive(_isSoundBtnClicked);
            GameBehaviourManager.Instance.AudioListener.enabled = !_isSoundBtnClicked;
        }
    }
}