using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum AudioClipsEnum
{

    None,

    _01_Instruction_0,
    _01_Instruction_1,
    _01_Instruction_2,
    _01_Instruction_3,

    _01_Crowd,
    _01_Amb,
    _01_CrowdUp,
    _01_CrowdUp2,
    _01_CityAmb,
    _01_MenAmb,
    _01_Men,
    _01_Woman,
    _01_Woman2,

    _02_Instruccion_0,
    _02_Instruction_1b,
    _02_Instruction_2,
    _02_Instruction_3,
    _02_Instruction_4,
    _02_Instruction_5,
    _02_Instruction_6,
    _02_Instruction_7,
    _02_Instruction_8,
    _02_Instruction_9,

    _03_Instruction_0,
    _03_Instruction_1,
    _03_Instruction_2,
    _03_Instruction_3,
    _03_Instruction_4,

    _03_ForestAmb,
    _03_Wind,

    // escena 1, añadidas despues
    _01_Instruction_1_Part1,
    _01_Instruction_1_part2

}

/// <summary>
/// Funciones para controlar el sonido, irá en el GameManager
/// </summary>
public class GameSoundManager : MonoBehaviour
{
    [Serializable]
    public class AudioClipData
    {
        [Header("Clip de audio")]
        public AudioClip audioClip;
        [Header("El nombre del clip correspondiente cargado en la enumeracion")]
        public AudioClipsEnum clipEnum;
        [Header("Descripción del clip")]
        [TextArea(1, 3)] public string description;

    }

    public static GameSoundManager instance;

    [Header("Ingresar todos los clips de audios del juego, por escena")]
    public AudioClipData[] scene_00_AudioClips;
    public AudioClipData[] scene_01_AudioClips;
    public AudioClipData[] scene_02_AudioClips;
    public AudioClipData[] scene_03_AudioClips;

    //[HideInInspector]
    public List<AudioClipData> allGameAudioClips = new List<AudioClipData>();

    [HideInInspector]
    public List<AudioSource> allAudioSourcesPlaying;


    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        AddAllClipsInOneAllGameCollection(scene_00_AudioClips);
        AddAllClipsInOneAllGameCollection(scene_01_AudioClips);
        AddAllClipsInOneAllGameCollection(scene_02_AudioClips);
        AddAllClipsInOneAllGameCollection(scene_03_AudioClips);
    }

    /// <summary>
    /// Añadimos todos los clips sueltos en una sola colección para poder buscarlos
    /// </summary>
    private void AddAllClipsInOneAllGameCollection(AudioClipData[] selectedSceneClips) {
        foreach (AudioClipData clipData in selectedSceneClips) {
            allGameAudioClips.Add(clipData);
        }
    }

    /// <summary>
    /// Sube o baja el volumen de un audio dependiendo de los parametros dados
    /// </summary>
    public IEnumerator ChangeVolume(AudioSource audioSource, float destineVolume, float secondsOfTransition) {

        if (secondsOfTransition < 0) { secondsOfTransition = 0; }

        if (destineVolume > 1) { destineVolume = 1; }
        else if (destineVolume < 0) { destineVolume = 0; }

        float volumeDiference = Mathf.Abs(audioSource.volume - destineVolume); // Obtenemos la diferencia entre volumenes

        if (volumeDiference == 0) { yield return null; } // Si no hay diferencia entre volumenes entonces salimos de la funcion

        float volumePerSecond = volumeDiference / secondsOfTransition; // Calculamos la fraccion de volumen por segundo

        // Si los segundos de transicion son 0 entonces subimos el volumen de una
        if (secondsOfTransition == 0) {
            audioSource.volume = destineVolume;
        }
        else {
            float volumePerCycle = volumePerSecond / 10; // Dividimos por 10 porque llamaremos a la funcion 10 veces por segundo

            if (destineVolume > audioSource.volume) {
                while (true) {
                    // Sumamos volumen
                    audioSource.volume += volumePerCycle;
                    if (audioSource.volume > destineVolume) { break; }
                    yield return new WaitForSeconds(.1f);
                }
            }
            else {
                while (true) {
                    // Sumamos volumen
                    audioSource.volume -= volumePerCycle;
                    if (audioSource.volume < destineVolume) { break; }
                    yield return new WaitForSeconds(.1f);
                }
            }
        }
    }

    /// <summary>
    /// Dado un audiosource y una enumeracion de clip, lo cambia
    /// </summary>
    public void ChangeAudioClip(AudioSource audioSource, AudioClipsEnum newClip) {
        audioSource.clip = GetAudioClipForEnum(newClip);
    }

    /// <summary>
    /// Busca el clip según la enumeración
    /// </summary>
    public AudioClip GetAudioClipForEnum(AudioClipsEnum clipEnum) {
        foreach (AudioClipData audioData in allGameAudioClips) {
            if (audioData.clipEnum == clipEnum) {
                return audioData.audioClip;
            }
        }
        Debug.LogError("El clip " + clipEnum + " no está cargado en el SoundController");
        return null;
    }


}

