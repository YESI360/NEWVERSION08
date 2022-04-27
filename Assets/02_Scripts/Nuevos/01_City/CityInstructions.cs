using UnityEngine;
using UnityEngine.Audio;
using Valve.VR;
using System.Collections;

public enum Sn_01_Instructions_Steps_enum
{
    Step0, Step1, Step2, Step3
}

[RequireComponent(typeof(SoundController))]
public class CityInstructions : MonoBehaviour
{
    SoundController soundController;
    public SoundController cityAmbientSC;

    [SerializeField] int CantidadDeVivosIntruccion_1; // Cantidfad de personajes spawneados
    [SerializeField] int CantidadDeVidosIntruccion_3;
    [SerializeField] SpawnerGeneral spawnScript;

    [HideInInspector]
    public Sn_01_Instructions_Steps_enum actualStep;

    [SerializeField] AudioMixer audioMixer;

    [Header("Objetos que se acercan al personaje para el sonido envolvente")]
    public FakePaneo volumenD;
    public FakePaneo volumenI;


    [Header("Delay entre las instrucciones")]
    [Range(0, 3600)] public float startDelay;
    [Range(0, 3600)] public float instructionsDelay;
    [Range(0, 3600)] public float changeSceneDelay;

    private int instructions = 0;
    private float targetVolumen = 0;
    [HideInInspector] public float currentVolumen = 0;
    //private int steps;

    bool micInput;

    private void Awake() {
        soundController = GetComponent<SoundController>();
    }

    private void Start() {
        NPDSensor.instance.soundController.SetVolume(0, 0); // Ponemos el volumen del PDSensor a 0
        soundController.PlaySourceWithDelay(startDelay); // Iniciamos la primera instrucción
        StartCoroutine(CheckInstructions()); // Iniciamos la coroutina que checkea instrucciones
        StartCoroutine(CheckMixerVolume()); // Iniciamos la coroutina que checkea el mixer
    }

    /// <summary>
    /// Manejador del Audio Mixer
    /// </summary>
    private IEnumerator CheckMixerVolume() {
        while (true) {
            if (currentVolumen != targetVolumen) {
                currentVolumen = Mathf.Lerp(currentVolumen, targetVolumen, .5f * Time.deltaTime);

                // Le dice al mixer (master en este caso) que se ponga en un volumen específico
                audioMixer.SetFloat("musicVol", Mathf.Lerp(currentVolumen, targetVolumen, .5f * Time.deltaTime));
            }
            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    /// Manejador de sonidos y acciones de instrucciones
    /// </summary>
    private IEnumerator CheckInstructions() {

        while (true) {

            if (soundController.GetIsPlaying() == false) {

                if ((Inputs.instance.CheckMicrophoneMinLoudness())/*Input.GetMouseButtonDown(0)*/)//
                {

                    if (instructions == 0)//00 
                    {
                        //flow.SetState(GameState0.Chest0);
                        print("Instruccion 0 completada");
                        volumenD.VolumenDown();
                        volumenI.VolumenDown();
                        instructions = 1;
                        currentVolumen = 0;
                        targetVolumen = -5f;
                        spawnScript.DestroyEntities(CantidadDeVivosIntruccion_1);
                        cityAmbientSC.SetVolume((CantidadDeVivosIntruccion_1 * 100 / spawnScript.maxSpawnCount) / 100, 1);
                        Debug.Log("nuevo Volumen de sonido en instruccion 0 " + (CantidadDeVivosIntruccion_1 * 100 / spawnScript.maxSpawnCount) / 100);

                        actualStep = Sn_01_Instructions_Steps_enum.Step0;
                    }
                    else if (instructions == 1)//01b
                    {
                        bool input = false;
                        bool twoPart = false;

                        print("Instruccion 1 completada");
                        NPDSensor.instance.ChangeVolume(0.2f, 3);

                        volumenD.VolumenDown();
                        volumenI.VolumenDown();
                        instructions = 2;
                        currentVolumen = -10;
                        targetVolumen = -17f;

                        // Activamos la primera parte
                        soundController.ChangeClip(AudioClipsEnum._01_Instruction_1_Part1);
                        soundController.PlaySourceWithDelay(instructionsDelay);
                        yield return new WaitForSeconds(instructionsDelay);

                        // Dejamos la coroutina a la espera para ejecutar la segunda parte
                        while (twoPart == false) {

                            // Cuando deje de sonar la instruccion anterior
                            if (soundController.GetIsPlaying() == false) {
                                // Activamos la segunda parte
                                soundController.ChangeClip(AudioClipsEnum._01_Instruction_1_part2);
                                soundController.PlaySource(); // Esta vez lo activamos sin delay
                                twoPart = true;
                            }
                            yield return new WaitForFixedUpdate();
                        }

                        while (input == false) {
                            // Si el input es falso sigue checkeando inputs
                            if (input == false) {
                                input = Inputs.instance.CheckMicrophoneMinLoudness();
                            }

                            // Si hay input de microfono
                            if (input) {
                                spawnScript.ChangeAnimation();
                                actualStep = Sn_01_Instructions_Steps_enum.Step1;
                                instructions = 2;
                                Debug.Log("Anim");
                            }
                            yield return new WaitForFixedUpdate();
                        }

                        // Comprobamos que no este sonando nada antes ejecutar la siguiente parte
                        while (soundController.GetIsPlaying()) {
                            yield return new WaitForFixedUpdate();
                        }

                        input = false;

                        print("Instruccion 2 completada");
                        NPDSensor.instance.ChangeVolume(0.3f, 3);

                        instructions = 2;
                        currentVolumen = -17;
                        targetVolumen = -25f;


                        soundController.ChangeClip(AudioClipsEnum._01_Instruction_2);
                        soundController.PlaySourceWithDelay(instructionsDelay); //
                        yield return new WaitForSeconds(instructionsDelay);

                        // Comprobamos que no este sonando nada antes ejecutar la siguiente parte
                        while (soundController.GetIsPlaying()) {
                            yield return new WaitForFixedUpdate();
                        }

                        // Comprobamos de no seguir hacia adelante si no hubo un input
                        while (input == false) {
                            if (Inputs.instance.CheckMicrophoneMinLoudness()) {
                                spawnScript.DestroyEntities(CantidadDeVidosIntruccion_3);
                                cityAmbientSC.SetVolume((CantidadDeVidosIntruccion_3 * 100 / spawnScript.maxSpawnCount) / 100, 1);
                                actualStep = Sn_01_Instructions_Steps_enum.Step2;
                                input = true;
                            }
                            yield return new WaitForFixedUpdate();
                        }

                    }
                    else if (instructions == 2) { //03 TRANS

                        Debug.Log("Iniciando audio de la transición de escena");
                        NPDSensor.instance.ChangeVolume(0.6f, 3);

                        soundController.ChangeClip(AudioClipsEnum._01_Instruction_3);
                        soundController.PlaySourceWithDelay(instructionsDelay); //
                        yield return new WaitForSeconds(instructionsDelay);
                        actualStep = Sn_01_Instructions_Steps_enum.Step3;

                        // Bloquea la ejecución de la accion de cambiar a la escena siguiente
                        while (soundController.GetIsPlaying()) {
                            yield return new WaitForSeconds(0.1f);
                        }

                        yield return new WaitForSeconds(changeSceneDelay); // Delay para el cambio de escena
                        SteamVR_LoadLevel.Begin("02_Shader");
                        SceneLoadController.instance.SceneChange(SceneEnum._02_Shader);
                        FlowManager.instance.SetState(GameState.NotStarted);

                        instructions++;
                    }
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }
}

