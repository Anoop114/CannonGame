using UnityEngine;
using Utils;

namespace CannonMachine
{
    public class CannonBallHit : MonoBehaviour
    {
        private CannonBallHit _mScript;

        private void Start()
        {
            _mScript = this;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Target")) return;
            StaticHelper.CannonBallHitObstetrical++;
            if (StaticHelper.CannonBallHitObstetrical >= 3)
            {
                GameBehaviourManager.Instance.UIManager.WinMenu();
            }
            else
            {
                Destroy(_mScript);
            }
        }
    }
}