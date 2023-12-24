using Player;
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

        [SerializeField] private PlayerAnimationController playerAnimationController;


        public PlayerAnimationController PlayerAnimationController => playerAnimationController;
    }
}