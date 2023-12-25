using CameraScript;
using CannonMachine;
using Player;
using Player.MovementController;
using SoundManager;
using UIScripts;
using UnityEngine;

namespace Utils
{
    public class GameBehaviourManager : MonoBehaviour
    {
        #region Singelton

        public static GameBehaviourManager Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        
        

        #endregion

        #region Private Variables

        [SerializeField] private PlayerAnimationController playerAnimationController;
        [SerializeField] private UIManager uIManager;
        [SerializeField] private SwipeAndHold4Directions swipeController;
        [SerializeField] private SoundBehaviour soundController;
        [SerializeField] private SmoothCameraFollow camScript;
        [SerializeField] private CannonController cannonMachineController;

        #endregion

        #region Global Refrences

        public CannonController CannonMachineController => cannonMachineController;
        public SmoothCameraFollow CamScript => camScript;
        public SoundBehaviour SoundController => soundController;
        public SwipeAndHold4Directions SwipeController => swipeController;
        public UIManager UIManager => uIManager;
        public PlayerAnimationController PlayerAnimationController => playerAnimationController;

        #endregion
    }
}