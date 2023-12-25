using UnityEngine;
using Utils;

namespace CannonMachine
{
    public class PlayerInteractWithCannon : MonoBehaviour
    {
        private PlayerInteractWithCannon _mScript;

        private void Start()
        {
            _mScript = this;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            if (StaticHelper.CannonBallPickupCount < 5)
            {
                GameBehaviourManager.Instance.UIManager.ErrorDisplayCannonMenu();
            }
            else
            {
                GameBehaviourManager.Instance.UIManager.DragDropCannonBallActive();
                Destroy(_mScript);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (StaticHelper.CannonBallPickupCount < 5)
            {
                GameBehaviourManager.Instance.UIManager.CollectCannonBallActive();
            }
        }
    }
}