using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGeneral : MonoBehaviour
{
    public int maxSpawnCount;
    //[SerializeField] private int cantidadVivos;

    [SerializeField] private GameObject[] prefab;

    [SerializeField] Transform[] spawns;

    private List<AIControllerGoalsGeneral> instances = new List<AIControllerGoalsGeneral>();

    public  IEnumerator Start()
    {
        for (int i = 0; i < maxSpawnCount; i++)
        {
            AIControllerGoalsGeneral newInstance = Instantiate 
               (prefab[Random.Range(0, prefab.Length)], 
               spawns[Random.Range(0, spawns.Length)].position, 
               Quaternion.Euler(0, Random.value * 360, 0),transform).GetComponent<AIControllerGoalsGeneral>();

            instances.Add(newInstance);

            yield return new WaitForSeconds(Random.value * 0.1f);
        }
        Debug.Log("Terminamos de instanciar");
    }

    public int DestroyEntities(int cantidadVivos)
    {
        while (instances.Count > cantidadVivos)
        {
            //Destroy(instances[0]);
            instances[0].GetComponent<AIControllerGoalsGeneral>().Destroy();
            instances.RemoveAt(0);
        }

        //foreach (AIControllerGoalsGeneral character in instances)
        //{
        //    character.ChangeState();
        //    //character.GetComponent<AudioSource>().volume = 0.2f;
        //    //character.GetComponent<bajarVolPasos>().BajarPasos(0.2f);
        //}

        return 1;
    }

    public int ChangeAnimation()
    {
        foreach (AIControllerGoalsGeneral character in instances)
        {
            character.ChangeState();
            //character.GetComponent<AudioSource>().volume = 0.2f;
            //character.GetComponent<bajarVolPasos>().BajarPasos(0.2f);
        }

        return 2;
    }

}
