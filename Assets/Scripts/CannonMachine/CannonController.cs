using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace CannonMachine
{
    public class CannonController : MonoBehaviour
    {
        #region Variables

        [Header("Shoot power")]
        [SerializeField] private float blastPower = 5;

        [Header("cannon references")]
        [SerializeField] private GameObject cannonball;
        [SerializeField] private Transform shotPoint;
        [SerializeField] private GameObject explosion;

        [Header("UI controller references")]
        [SerializeField] private Slider xAxisRotation;
        [SerializeField] private Slider yAxisRotation;
        [SerializeField] private Button shootBtn;
    
        public Transform ShotPoint => shotPoint;
        public float BlastPower => blastPower;
        public bool isCannonStart;
        #endregion
    
        private void Start()
        {
            xAxisRotation.onValueChanged.AddListener(RotateCannonXAxis);
            yAxisRotation.onValueChanged.AddListener(RotateCannonYAxis);
            shootBtn.onClick.AddListener(ShootCannonBallAction);
        }

        private void OnEnable() => isCannonStart = true;

        private void OnDisable() => isCannonStart = false;

        #region Cannon movement

        private void RotateCannonYAxis(float angle)
        {
            var mTransform = transform;
            var rot = mTransform.eulerAngles;
            rot.z = angle;
            mTransform.eulerAngles = rot;
        }

        private void RotateCannonXAxis(float angle)
        {
            var mTransform = transform;
            var rot = mTransform.eulerAngles;
            rot.y = angle;
            mTransform.eulerAngles = rot;
        }
        

        #endregion

        private void ShootCannonBallAction()
        {
            var position = shotPoint.position;
            var rotation = shotPoint.rotation;
        
            var createdCannonball = Instantiate(cannonball, position, rotation);
            createdCannonball.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * blastPower;
            
            // Added explosion for added effect
            Destroy(Instantiate(explosion, position, rotation), 2);

            // Shake the screen for added effect
            ActionHelper.OnScreenShakeCall?.Invoke(0.2f);
        }
    }
}
