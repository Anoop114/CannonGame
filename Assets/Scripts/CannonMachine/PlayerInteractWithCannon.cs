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
                Debug.Log("Player Need to collect ball first");
            }
            else
            {
                GameBehaviourManager.Instance.UIManager.DragDropCannonBallActive();
                Destroy(_mScript);
            }
        }
    }
}