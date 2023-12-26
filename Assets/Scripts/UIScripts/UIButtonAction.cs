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

        [Header("swap controller")]
        [SerializeField] private Toggle joystick;
        [SerializeField] private Toggle swipe;
        private void Start()
        {
            musicSound.onValueChanged.AddListener(ChangeMusicSoundValue);
            soundSound.onValueChanged.AddListener(ChangeSoundSoundValue);
            
            joystick.onValueChanged.AddListener(ChangeJoystick);
            swipe.onValueChanged.AddListener(ChangeSwipe);
        }

        private void ChangeSwipe(bool arg0)
        {
            joystick.isOn = !arg0;
            swipe.interactable = !arg0;
            StaticHelper.IsUseJoystick = !arg0;
            GameBehaviourManager.Instance.JoystickAndSwipeController(!arg0);
        }

        private void ChangeJoystick(bool arg0)
        {
            swipe.isOn = !arg0;
            joystick.interactable = !arg0;
            StaticHelper.IsUseJoystick = arg0;
            GameBehaviourManager.Instance.JoystickAndSwipeController(arg0);
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