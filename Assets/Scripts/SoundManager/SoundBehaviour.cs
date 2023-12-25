using UnityEngine;

namespace SoundManager
{
    public class SoundBehaviour : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource globalAudioSource;
        [SerializeField] private AudioSource walkingAudioSource;
        [SerializeField] private AudioSource interactionAudioSource;

        [Header("AudioClip")] 
        [SerializeField] private AudioClip gameSound;
        [SerializeField] private AudioClip walk;
        [SerializeField] private AudioClip run;
        [SerializeField] private AudioClip pickUp;
        [SerializeField] private AudioClip fire;

        private void Start()
        {
            globalAudioSource.clip = gameSound;
            globalAudioSource.Play();
        }

        public void PlayWalkSound()
        {
            walkingAudioSource.Pause();
            walkingAudioSource.clip = walk;
            walkingAudioSource.Play();
        }
        
        public void PlayRunSound()
        {
            walkingAudioSource.Pause();
            walkingAudioSource.clip = run;
            walkingAudioSource.Play();
        }

        public void StopWalkRunSound()
        {
            walkingAudioSource.Stop();
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
    }
}