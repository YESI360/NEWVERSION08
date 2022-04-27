using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab = null;
    public int maxSpawnCount;

    private IEnumerator Start()
    {
        for (int i = 0; i < maxSpawnCount; i++)
        {
            // pick a random spawn position
            Vector3 spawnPosition = Random.insideUnitSphere * 5f;
            spawnPosition.y = 0;
            spawnPosition.z = 18;
            spawnPosition.x = 8;

            // with random rotation
            Instantiate(prefab, spawnPosition, Quaternion.Euler(0, Random.value * 360, 0));

            // randomly delay before respawing
            yield return new WaitForSeconds(Random.value * 0.1f);
        }
    }
}
