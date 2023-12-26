using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace CannonMachine
{
    public class PlayerInteractWithCannon : MonoBehaviour
    {
        private PlayerInteractWithCannon _mScript;
        [SerializeField] private GameObject errorDisplay;
        private void Start()
        {
            _mScript = this;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            if (StaticHelper.CannonBallPickupCount < 5)
            {
                errorDisplay.SetActive(true);
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
                errorDisplay.SetActive(false);
            }
        }
    }
}