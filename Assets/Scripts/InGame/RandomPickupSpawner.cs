using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InGame
{
    public class RandomPickupSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnPointMinX;
        [SerializeField] private float spawnPointMaxX;
        [SerializeField] private float spawnPointMinZ;
        [SerializeField] private float spawnPointMaxZ;

        [SerializeField] private GameObject spawnObject;
        [SerializeField] private GameObject randomObject;
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

        private void SpawnRandomCannonBall(GameObject spawnObj)
        {
            var randomXpos = Random.Range(spawnPointMinX, spawnPointMaxX);
            var randomZpos = Random.Range(spawnPointMinZ, spawnPointMaxZ);

            var placePos = new Vector3(randomXpos, 2, randomZpos);
            Instantiate(spawnObj, placePos, quaternion.identity);
        }
    }
}