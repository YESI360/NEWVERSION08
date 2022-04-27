using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LibPdInstance))]
[RequireComponent(typeof(SoundController))]
[ExecuteAlways]
public class NPDSensor : MonoBehaviour
{
    // instancia estatica
    public static NPDSensor instance;

    [Header("Coeficientes")]
    [Range(0, 10)] public int inhale;
    [Range(0, 10)] public int exhale;

    [Header("Adjuntar controllers")]
    public SoundController soundController;
    public LibPdInstance libPdInstance;

    // Cada vez que iniciemos haremos que la instancia sea el pdSensor de la escena
    private void Awake() {
        if (Application.isPlaying) {
            if (instance == null) {
                instance = this;
            }
        }

        if (soundController == null) { soundController = GetComponent<SoundController>(); }
        if (libPdInstance == null) { libPdInstance = GetComponent<LibPdInstance>(); }

        if (Application.isPlaying) {
            StartCoroutine(ListenToActivate()); ;
        }
    }

    IEnumerator ListenToActivate() {
        yield return new WaitForSeconds(5);
        while (true) {
            if (RvInputs.chest_Calibrated == 2) { SoundUp(); }
            else { SoundDown(); }
            yield return new WaitForFixedUpdate();
        }
    }

    public void ChangeVolume(float destineValue, float secondsOfTransition) {
        soundController.SetVolume(destineValue, secondsOfTransition);
    }

    public void SoundUp() {
        libPdInstance.SendFloat("proximity", inhale);
    }

    public void SoundDown() {
        libPdInstance.SendFloat("proximity", exhale);
    }


}
