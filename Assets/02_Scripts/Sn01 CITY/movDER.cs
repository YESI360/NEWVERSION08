using UnityEngine;

// Mov Der Mov Izq son objetos que van acercandose al personaje al cargar la escena.

[RequireComponent(typeof(SoundController))]
public class movDER : MonoBehaviour
{
    public GameObject CubeVocesDER;
    public float movementSpeed;
    public float SpeedVol;
    public AudioSource Voces;

    public Vector3 target = new Vector3(-151, 139, -163);
    void Start()
    {
        GetComponent<AudioSource>().volume = 1;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }

    public void VolumenDown()
    {
        Voces.volume -= Time.deltaTime * SpeedVol;
        //Voces.volume = 0.6f;
    }



}
