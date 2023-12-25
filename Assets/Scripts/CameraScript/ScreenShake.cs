using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace CameraScript
{
    public class ScreenShake : MonoBehaviour
    {
        #region Variables

        private float _shakeAmount;
        private Vector3 _startingPosition;
        private bool _isShakeStart;

        #endregion

        #region Unity Event

        private void Start() => _startingPosition = transform.position;

        private void OnEnable() => ActionHelper.OnScreenShakeCall += ScreenShakeCall;
        
        private void StopShake() => _isShakeStart = false;

        private void OnDisable() => ActionHelper.OnScreenShakeCall -= ScreenShakeCall;

        #endregion

        private void ScreenShakeCall(float shakeAmount)
        {
            _isShakeStart = true;
            Invoke(nameof(StopShake),2f);
        }
        
        // screen shake on shoot.
        private void Update()
        {
            if(!_isShakeStart) return;
            _shakeAmount = Mathf.Lerp(_shakeAmount, 0, 0.02f);
            transform.position = _startingPosition + Random.onUnitSphere * _shakeAmount;
        }
    }
}
