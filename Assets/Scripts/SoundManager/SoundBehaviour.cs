using UnityEngine;

namespace SoundManager
{
    public class SoundBehaviour : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource globalAudioSource;
        [SerializeField] private AudioSource interactionAudioSource;

        [Header("AudioClip")] 
        [SerializeField] private AudioClip gameSound;
        [SerializeField] private AudioClip pickUp;
        [SerializeField] private AudioClip fire;

        private void Start()
        {
            globalAudioSource.clip = gameSound;
            globalAudioSource.Play();
        }
        
        
        public void PlayPickupAudio()
        {
            interactionAudioSource.Pause();
            interactionAudioSource.clip = pickUp;
            interactionAudioSource.Play();
        }

        public void PlayFireSound()
        {
            interactionAudioSource.Stop();
            interactionAudioSource.clip = fire;
            interactionAudioSource.Play();
        }

        public void ChangeSoundVolume(float volume)
        {
            interactionAudioSource.volume = volume;
        }

        public void ChangeMusicVolume(float volume)
        {
            globalAudioSource.volume = volume;
        }
    }
}