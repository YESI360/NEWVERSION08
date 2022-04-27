using UnityEngine;

[ExecuteAlways]
public class SoundController : MonoBehaviour
{
    [Header("El AudioSource en cuestión")]
    [SerializeField] public AudioSource audioSource;

    [Header("Por si se quiere presetear estos valores para usarlos en los llamados a este script")]
    [Range(0, 1)] public float maxVolume;
    [Range(0, 1)] public float minVolume;

    [Range(0, 3600)]
    [Header("Indicar el tiempo de transición de volumen de sonido")]
    public float transitionTime;

    // Indice de este AudioSource en la coleccion general de AudioSources que están siendo ejecutados
    private int indexInExecutedASources;

    // Nota, se ejecuta siempre
    public void Awake() {
        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void Start() {
        if (Application.isPlaying) {
            if (audioSource.playOnAwake) {
                GameSoundManager.instance.allAudioSourcesPlaying.Add(audioSource);
            }
        }
    }

    /// <summary>
    /// Devuelve el volumen actual
    /// </summary>
    public float GetVolume() {
        return audioSource.volume;
    }

    /// <summary>
    /// Play Audio Source
    /// </summary>
    public void PlaySource() {
        audioSource.Play();
        AddInAllSourcesPlaying();
    }

    /// <summary>
    /// Para ejecutar el clip con delay
    /// </summary>
    public void PlaySourceWithDelay(float secondsOfDelay) {
        audioSource.PlayDelayed(secondsOfDelay);
    }

    /// <summary>
    /// Stop Audio Source
    /// </summary>
    public void StopSound() {
        audioSource.Stop();
        RemoveFromAllSourcesPlaying();
    }

    /// <summary>
    /// Setea el volumen
    /// </summary>
    public void SetVolume(float destineVolume, float secondsOfTransition) {
        StartCoroutine(GameSoundManager.instance.ChangeVolume(audioSource, destineVolume, secondsOfTransition));
    }

    /// <summary>
    /// Cambia el clip de sonido dado su nombre por enumeración
    /// </summary>
    public void ChangeClip(AudioClipsEnum newClip) {
        GameSoundManager.instance.ChangeAudioClip(audioSource, newClip);
    }

    /// <summary>
    /// Lo añade a la lista de audiosources en ejecución
    /// </summary>
    private void AddInAllSourcesPlaying() {
        GameSoundManager.instance.allAudioSourcesPlaying.Add(audioSource);
        indexInExecutedASources = GameSoundManager.instance.allAudioSourcesPlaying.Count - 1;
    }
    /// <summary>
    /// Lo remueve de la lista de audioSources en ejecución
    /// </summary>
    private void RemoveFromAllSourcesPlaying() {
        if (audioSource.isPlaying) {
            GameSoundManager.instance.allAudioSourcesPlaying.RemoveAt(indexInExecutedASources);
        }
    }

    /// <summary>
    /// Setea el loop del AudioSource a true
    /// </summary>
    public void SetLoopTrue() {
        audioSource.loop = true;
    }

    /// <summary>
    /// Setea el loop del AudioSource a false
    /// </summary>
    public void SetLoopFalse() {
        audioSource.loop = false;
    }

    /// <summary>
    /// Para verificar si se está ejecutando el audio source o no
    /// </summary>
    public bool GetIsPlaying() {
        return audioSource.isPlaying;
    }

}
