using System;
using UnityEngine;
using Utils;

namespace PickUp
{
    public class PickUpItems : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pickup"))
            {
                ActionHelper.OnPickupAction?.Invoke(true,other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Pickup"))
            {
                ActionHelper.OnPickupAction?.Invoke(false,other.gameObject);
            }
        }
    }
}