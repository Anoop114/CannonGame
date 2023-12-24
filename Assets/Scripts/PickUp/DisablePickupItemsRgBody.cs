using System;
using UnityEngine;

namespace PickUp
{
    public class DisablePickupItemsRgBody : MonoBehaviour
    {
        private Rigidbody _mBody;
        private Collider _mCollider;
        private DisablePickupItemsRgBody _mScript;
        private void Start()
        {
            _mBody = GetComponent<Rigidbody>();
            _mCollider = GetComponent<Collider>();
            _mScript = GetComponent<DisablePickupItemsRgBody>();
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