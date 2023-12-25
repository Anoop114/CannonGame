using System.Collections.Generic;
using UnityEngine;

namespace CannonMachine
{
    public class DrawProjection : MonoBehaviour
    {
        #region Variables

        private CannonController cannonController;
        private LineRenderer lineRenderer;

        [SerializeField] private int numPoints = 50;
        [SerializeField] private float timeBetweenPoints = 0.1f;
        [SerializeField] private LayerMask collectableLayers;

        #endregion

        private void Start()
        {
            cannonController = GetComponent<CannonController>();
            lineRenderer = GetComponent<LineRenderer>();
        }


        // Draw line Render path.
        private void Update()
        {
            lineRenderer.positionCount = numPoints;
            var points = new List<Vector3>();
            var startingPosition = cannonController.ShotPoint.position;
            var startingVelocity = cannonController.ShotPoint.up * cannonController.BlastPower;
            for (float t = 0; t < numPoints; t += timeBetweenPoints)
            {
                var newPoint = startingPosition + t * startingVelocity;
                newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
                points.Add(newPoint);

                if (Physics.OverlapSphere(newPoint, 2, collectableLayers).Length <= 0) continue;
                lineRenderer.positionCount = points.Count;
                break;
            }

            lineRenderer.SetPositions(points.ToArray());
        }
    }
}
