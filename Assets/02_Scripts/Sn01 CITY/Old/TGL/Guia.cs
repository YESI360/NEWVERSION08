using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Guia : MonoBehaviour
{

    [SerializeField] AudioSource audioS;
    [SerializeField] AudioClip[] clips;
    public int instructions = 0;
    public int delay;

    //public AudioSource Instruccion00; //no uso get component xq tengo + de 1 audioSource


    private void Start()
    {
        //Instruccion00.PlayDelayed(10);
        audioS.PlayDelayed(10);
        instructions = 1;
}
    void Update()
    {

        if (audioS.isPlaying)
            return;
    }

    public void instruccion00 ()
    {
        instructions = 2;
        audioS.clip = clips[instructions - 1];
        audioS.PlayDelayed(delay);
        return;
    }

    public void instruccion01()
    {
        instructions = 3;
        audioS.clip = clips[instructions - 1];
        audioS.PlayDelayed(delay);
        return;
    }

    public void instruccion02()
    {
        instructions = 4;
        audioS.clip = clips[instructions - 1];
        audioS.PlayDelayed(delay);
        return;
    }

    public void instruccion03()
    {
        instructions = 5;
        audioS.clip = clips[instructions - 1];
        audioS.PlayDelayed(delay);
        return;
    }

    public void instruccion04()
    {
        instructions = 6;
        audioS.clip = clips[instructions - 1];
        audioS.PlayDelayed(delay);
        return;
    }

    public void instruccion05()
    {
        instructions = 7;
        audioS.clip = clips[instructions - 1];
        audioS.PlayDelayed(delay);
        return;
    }

    //public void instruccion06()
    //{
    //    audioS.clip = clips[instructions - 1];
    //    audioS.PlayDelayed(delay);
    //}

}
