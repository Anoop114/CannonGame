using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InGame
{
    public class RandomPickupSpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float spawnPointMinX;
        [SerializeField] private float spawnPointMaxX;
        [SerializeField] private float spawnPointMinZ;
        [SerializeField] private float spawnPointMaxZ;

        [SerializeField] private GameObject spawnObject;
        [SerializeField] private GameObject randomObject;
        [SerializeField] private Transform spawnParent;

        #endregion
        
        private void Start()
        {
            var i = 0;
            while (i < 10)
            {
                SpawnRandomCannonBall(spawnObject);
                i++;
            }

            i = 0;
            while (i<20)
            {
                SpawnRandomCannonBall(randomObject);
                i++;
            }
        }

        // call spawn random ball and cubes.
        private void SpawnRandomCannonBall(GameObject spawnObj)
        {
            var randomXpos = Random.Range(spawnPointMinX, spawnPointMaxX);
            var randomZpos = Random.Range(spawnPointMinZ, spawnPointMaxZ);

            var placePos = new Vector3(randomXpos, 2, randomZpos);
            var tempObject = Instantiate(spawnObj, placePos, quaternion.identity);
            tempObject.transform.parent = spawnParent;
        }

        public void DestroySpawnObjects()
        {
            Destroy(spawnParent.gameObject);
        }
    }
}