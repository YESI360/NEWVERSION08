using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMB : MonoBehaviour
{
    public GameObject prefab = null;
    public int maxSpawnCount;
    private List<GameObject> instances = new List<GameObject>();
    public int cantidadVivos;

    public  IEnumerator Start()
    {
        //Debug.Log($"[SpawnerM4] Starting spawn loop with { nameof(maxSpawnCount) } = { maxSpawnCount }");
        for (int i = 0; i < maxSpawnCount; i++)
        {
            //Debug.Log($"[SpawnerM4] Step #{ i }");

            //////// pick a random spawn position      
            Vector3 spawnPos = Random.insideUnitSphere * 5f;
            spawnPos.x = transform.position.x;
            spawnPos.y = transform.position.y;
            spawnPos.z = transform.position.z;

            //////with random rotation
            var newInstance = Instantiate(prefab, spawnPos, Quaternion.Euler(0, Random.value * 360, 0),transform);
            instances.Add(newInstance);

            // randomly delay before respawing
            yield return new WaitForSeconds(Random.value * 0.1f);
        }
        //Debug.Log($"[SpawnerM4] Spawn loop finished");
    }

    //public void ResetSpawn(int newMaxSpawnCount)
    //{
    //    Debug.Log($"[SpawnerM4] Spawn loop interruped");
    //    StopAllCoroutines();
    //    //maxSpawnCount = newMaxSpawnCount;
    //    newMaxSpawnCount = maxSpawnCount;
    //    StartCoroutine(Start());
    //}

    public void apagar(int cantidadVivos)
    {
        float alpha = 1;
        while (instances.Count > cantidadVivos)
        {
            //Destroy(instances[0]);
            instances.RemoveAt(0);
            print(instances[0].GetComponentInChildren<MeshRenderer>().materials[0].name);
            //instances[0].GetComponentInChildren<MeshRenderer>().materials[0].color = Color.green;

            alpha = instances[0].GetComponentInChildren<MeshRenderer>().materials[0].color.a;

            while (alpha > 0)
            {
                alpha -= 0.01f * Time.deltaTime;
                instances[0].GetComponentInChildren<MeshRenderer>().materials[0].color = new Color(0, 0, 0, alpha);
            }
        }
    }

}
