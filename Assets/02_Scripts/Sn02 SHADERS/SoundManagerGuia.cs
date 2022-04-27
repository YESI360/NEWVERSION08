using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerGuia : MonoBehaviour
{
    public static SoundManagerGuia instance;

    public AudioSource audioSource;
    public AudioClip[] clips;
    public AudioClip audioClipInstruccion01;//where is AIR
    public AudioClip audioClipInstruccion02;//AIR in AIR out
    public AudioClip audioClipInstruccion02B;//AIR out
    public AudioClip audioClipInstruccion03;//ITS ME!
    public AudioClip audioClipInstruccion04;//STAND UP
    public AudioClip audioClipInstruccion05;//HANDS IN WAIST
    public AudioClip audioClipInstruccion06;//
    public AudioClip audioClipInstruccion07;//
    public AudioClip audioClipInstruccion08;//

    //public AudioSource Instruccion00; //no uso get component xq tengo + de 1 audioSource
    public float delay = 2;
    public float volume = 0.5f;
    public bool IsPlaying => audioSource.isPlaying;/// CLIPS

    private void Awake()//singleton
    {
        if (SoundManagerGuia.instance == null)
        {
            SoundManagerGuia.instance = this;
        }
        else if (SoundManagerGuia.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        //Instruccion00.PlayDelayed(delay);
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            audioSource.PlayOneShot(audioClipInstruccion04);
        }
        if (Input.GetKeyDown("g"))
        {
            audioSource.PlayOneShot(audioClipInstruccion05);
        }
        if (Input.GetKeyDown("h"))
        {
            audioSource.PlayOneShot(audioClipInstruccion06);
        }
        if (Input.GetKeyDown("j"))
        {
            audioSource.PlayOneShot(audioClipInstruccion07);
        }
        if (Input.GetKeyDown("k"))
        {
            audioSource.PlayOneShot(audioClipInstruccion08);
        }


    }
    public void PlayInstruccion01()
    {
        audioSource.PlayOneShot(audioClipInstruccion01);        
        //PlayAudioClip(audioClipInstruccion01);
    }

    public void PlayInstruccion02()
    {
        audioSource.PlayOneShot(audioClipInstruccion02);
        //audio01.PlayOneShot(audioClipInstruccion02);
        //PlayAudioClip(audioClipInstruccion02);
    }

    public void PlayInstruccion02B()
    {
        audioSource.PlayOneShot(audioClipInstruccion02B);
        //audio01.PlayOneShot(audioClipInstruccion02);
        //PlayAudioClip(audioClipInstruccion02);
    }

    public void PlayInstruccion03()
    {
        audioSource.PlayOneShot(audioClipInstruccion03);
        //PlayAudioClip(audioClipInstruccion03);
    }

    public void PlayInstruccion04()
    {
        audioSource.PlayOneShot(audioClipInstruccion04);
        //PlayAudioClip(audioClipInstruccion033);
    }

    public void PlayInstruccion05()
    {
        audioSource.PlayOneShot(audioClipInstruccion05);
        //PlayAudioClip(audioClipInstruccion05);
    }

    public void PlayInstruccion06()
    {
        audioSource.PlayOneShot(audioClipInstruccion06);
        //PlayAudioClip(audioClipInstruccion05);
    }

    public void PlayInstruccion07()
    {
        audioSource.PlayOneShot(audioClipInstruccion07);
        //PlayAudioClip(audioClipInstruccion05);
    }

    public void PlayInstruccion08()
    {
        audioSource.PlayOneShot(audioClipInstruccion08);
        //PlayAudioClip(audioClipInstruccion05);
    }


    private void PlayAudioClip(AudioClip audioclip)
    {
        //Instruccion00.clip = audioclip;//?
       StartCoroutine(CoPlayDelayedClip(audioclip, delay));
    }

    IEnumerator CoPlayDelayedClip(AudioClip _clip, float _delay)//TODOS CON DELAY X CORRUTINA
    {
        yield return new WaitForSeconds(_delay);//delay audioclips
        //Instruccion00.PlayOneShot(_clip);//to avoid overlap
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    private void OnDestroy()//singleton
    {
        if (SoundManagerGuia.instance == this)
        {
            SoundManagerGuia.instance = null;
        }
    }
}

