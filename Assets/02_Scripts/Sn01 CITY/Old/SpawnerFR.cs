using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFR : MonoBehaviour
{
    public GameObject prefab = null;
    public int maxSpawnCount;
    public GameObject spawnPos;
    private List<GameObject> instances = new List<GameObject>();
    public int cantidadVivos4;

    public IEnumerator Start()
    {
        //pasosFR = GetComponent<AudioSource>();
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
    public void apagar4(int cantidadVivos4)
    {
        while (instances.Count > cantidadVivos4)
        {
            Destroy(instances[0]);
            instances.RemoveAt(0);
        }
    }

}
