using System.Collections;
using UnityEngine;

public enum Sn_02_Instructions_Steps_enum
{
    None, Instruction_00, Instruction_01, Instruction_02, Instruction_03, Instruction_04,
    Instruction_05, Instruction_06, Instruction_07, Instruction_08, Instruction_09
}

public class ShaderInstructions : MonoBehaviour
{

    // El Script SoundController para manipular el AudioSource
    public SoundController soundController;

    [Header("Delay entre las instrucciones")]
    [Range(0, 3600)] public float startDelay;
    [Range(0, 3600)] public float instructionsDelay;
    [Range(0, 3600)] public float changeSceneDelay;

    [HideInInspector]
    public Sn_02_Instructions_Steps_enum lastInstructionExecuted = Sn_02_Instructions_Steps_enum.None;
    private bool executionRequired = false;
    private Sn_02_Instructions_Steps_enum instructionRequired = Sn_02_Instructions_Steps_enum.Instruction_00;

    private void Start() {
        soundController = GetComponent<SoundController>();
        //NPDSensor.instance.soundController.SetVolume(0, 0); // Ponemos el volumen del PDSensor a 0
        StartCoroutine(CheckInstructions()); // Iniciamos la coroutina que checkea instrucciones
        ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_00); // Iniciamos la primera instrucción
    }

    /// <summary>
    /// Es una peticion a ejecutar una instruccion desde ShaderManager, cuando se ejecutan los sensores de la panza
    /// </summary>
    public void ExecuteInstruction(Sn_02_Instructions_Steps_enum instructionRequired) {
        executionRequired = true;
        this.instructionRequired = instructionRequired;
    }

    private IEnumerator CheckInstructions() {

        while (true) {
            // Si no hay nada sonando entoneces hacemos el checkeo a cerca de cual es la instruccion a ejecutar
            if (soundController.GetIsPlaying() == false) {
                if (executionRequired) {

                    // Indicamos que la instruccion ya fue procesada
                    executionRequired = false;

                    switch (instructionRequired) {
                        case Sn_02_Instructions_Steps_enum.Instruction_00:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.None) {

                                CommonInstructionProcess(0, instructionRequired,
                                    AudioClipsEnum._02_Instruccion_0, startDelay, 1, 0);

                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }

                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_01:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_00) {
                                CommonInstructionProcess(1, instructionRequired,
                                AudioClipsEnum._02_Instruction_1b, instructionsDelay, 1, 0);

                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }
                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_02:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_01) {
                                CommonInstructionProcess(2, instructionRequired,
                                AudioClipsEnum._02_Instruction_2, instructionsDelay, 1, 0);

                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }
                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_03:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_02) {
                                CommonInstructionProcess(3, instructionRequired,
                                AudioClipsEnum._02_Instruction_3, instructionsDelay, 1, 0);

                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }
                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_04:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_03) {
                                CommonInstructionProcess(4, instructionRequired,
                                AudioClipsEnum._02_Instruction_4, instructionsDelay, 1, 0);

                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }
                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_05:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_04) {
                                CommonInstructionProcess(5, instructionRequired,
                                AudioClipsEnum._02_Instruction_5, instructionsDelay, 1, 0);

                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }
                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_06:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_05) {
                                CommonInstructionProcess(6, instructionRequired,
                                AudioClipsEnum._02_Instruction_6, instructionsDelay, 1, 0);
                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }
                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_07:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_06) {
                                CommonInstructionProcess(7, instructionRequired,
                                AudioClipsEnum._02_Instruction_7, instructionsDelay, 1, 0);
                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }
                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_08:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_07) {
                                CommonInstructionProcess(8, instructionRequired,
                                AudioClipsEnum._02_Instruction_8, instructionsDelay, 1, 0);
                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);
                            }
                            break;
                        case Sn_02_Instructions_Steps_enum.Instruction_09:

                            //Comprobamos la instruccion anterior
                            if (lastInstructionExecuted == Sn_02_Instructions_Steps_enum.Instruction_08) {
                                CommonInstructionProcess(9, instructionRequired,
                                AudioClipsEnum._02_Instruction_9, instructionsDelay, 1, 0);
                                // Espera sobre el tiempo de ejecucion de la instruccion
                                yield return new WaitForSeconds(instructionsDelay);

                            }
                            break;
                    }
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }
    

    private void CommonInstructionProcess(int instructionNumber, Sn_02_Instructions_Steps_enum actualInstruction,
        AudioClipsEnum nextClip, float clipDelay, float pdSensorNewVolume, float pdSensorSecondsOfStransition) {
        Debug.Log("Instruction " + instructionNumber + " Completed!");
        lastInstructionExecuted = actualInstruction;
        soundController.ChangeClip(nextClip);
        soundController.PlaySourceWithDelay(clipDelay);
        NPDSensor.instance.ChangeVolume(pdSensorNewVolume, pdSensorSecondsOfStransition);
    }
}