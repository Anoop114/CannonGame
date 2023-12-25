using System;
using Unity.Mathematics;
using UnityEngine;
using Utils;
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

        private void OnEnable() => ActionHelper.OnCannonMachineActive += AllSpawnObjectsDisable;

        private void OnDisable() => ActionHelper.OnCannonMachineActive -= AllSpawnObjectsDisable;

        // call spawn random ball and cubes.
        private void SpawnRandomCannonBall(GameObject spawnObj)
        {
            var randomXpos = Random.Range(spawnPointMinX, spawnPointMaxX);
            var randomZpos = Random.Range(spawnPointMinZ, spawnPointMaxZ);

            var placePos = new Vector3(randomXpos, 2, randomZpos);
            var tempObject = Instantiate(spawnObj, placePos, quaternion.identity);
            tempObject.transform.parent = spawnParent;
        }

        private void AllSpawnObjectsDisable()
        {
            spawnParent.gameObject.SetActive(false);
        }
    }
}