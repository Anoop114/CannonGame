using UnityEngine;

namespace PickUp
{
    public class DisablePickupItemsRgBody : MonoBehaviour
    {
        private Rigidbody _mBody;
        private Collider _mCollider;
        private DisablePickupItemsRgBody _mScript;
        [SerializeField] private bool isBall;
        private void Start()
        {
            _mScript = GetComponent<DisablePickupItemsRgBody>();
            if (!isBall)
            {
                Destroy(_mScript);
                return;
            }
            _mBody = GetComponent<Rigidbody>();
            _mCollider = GetComponent<Collider>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ground")) return;
            Destroy(_mBody);
            _mCollider.isTrigger = true;
            Destroy(_mScript);
        }
    }
}