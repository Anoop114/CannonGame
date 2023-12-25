using UnityEngine;

namespace CameraScript
{
    public class SmoothCameraFollow : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform cannonPos;
        [SerializeField] private Transform target;
        [SerializeField] private float smoothTime;
        private Vector3 _offset;
        private Vector3 _currentVelocity = Vector3.zero;
        private bool _isPosChangeToCannon;
        #endregion
    
        #region Unity callbacks
    
        private void Awake() => _offset = transform.position - target.position;

        private void LateUpdate()
        {
            if(_isPosChangeToCannon)return;
            var targetPosition = target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        }
        #endregion

        public void UpdateCameraPosToCannon()
        {
            _isPosChangeToCannon = true;
            transform.SetPositionAndRotation(cannonPos.position,cannonPos.rotation);
        }
    }
}