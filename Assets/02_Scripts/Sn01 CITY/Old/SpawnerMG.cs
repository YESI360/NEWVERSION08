using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMG : MonoBehaviour
{
    public GameObject prefab = null;
    public int maxSpawnCount;
    public GameObject spawnPos;
    private List<GameObject> instances = new List<GameObject>();
    public int cantidadVivos2;

    public IEnumerator Start()
    {
        for (int i = 0; i < maxSpawnCount; i++)
        {
            // pick a random spawn position
            Vector3 spawnPos = Random.insideUnitSphere * 5f;
            spawnPos.x = transform.position.x;
            spawnPos.y = transform.position.y;
            spawnPos.z = transform.position.z;

            // with random rotation
            var newInstance = Instantiate(prefab, spawnPos, Quaternion.Euler(0, Random.value * 360, 0));
            instances.Add(newInstance);
            // randomly delay before respawing
            yield return new WaitForSeconds(Random.value * 0.1f);
        }

    }

    public void apagar2(int cantidadVivos2)
    {
        while (instances.Count > cantidadVivos2)
        {
            Destroy(instances[0]);
            instances.RemoveAt(0);
        }
    }

    //public void apagar2 (int amount)
    //{
    //    for (int i =0; i< amount; i++)
    //    {
    //        if (instances.Count == 0)
    //            continue;

    //        Destroy(instances[0]);
    //        instances.RemoveAt(0);
    //    }
    //}
}
