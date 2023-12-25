using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UIScripts
{
    public class UIButtonAction : MonoBehaviour
    {
        [Header("sound Btn")]
        [SerializeField] private Slider musicSound;
        [SerializeField] private Slider soundSound;
        [SerializeField] private GameObject musicEnd;
        [SerializeField] private GameObject soundEnd;
        private void Start()
        {
            musicSound.onValueChanged.AddListener(ChangeMusicSoundValue);
            soundSound.onValueChanged.AddListener(ChangeSoundSoundValue);
        }

        private void ChangeSoundSoundValue(float volume)
        {
            GameBehaviourManager.Instance.SoundController.ChangeSoundVolume(volume);
            soundEnd.SetActive(volume <= 0);
        }

        private void ChangeMusicSoundValue(float volume)
        {
            GameBehaviourManager.Instance.SoundController.ChangeMusicVolume(volume);
            musicEnd.SetActive(volume <= 0);
        }
    }
}