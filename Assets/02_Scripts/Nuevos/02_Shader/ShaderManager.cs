using UnityEngine;
using Valve.VR;


public class ShaderManager : MonoBehaviour
{
    public static ShaderManager instance;

    public enum ShaderSteps { None, Hands, Mirror, Guia, Collider }
    public ShaderSteps actualShaderStep { get; private set; } = ShaderSteps.None;

    [Header("Agregar manualmente el GO que contiene al Script ShaderInstructions")]
    public ShaderInstructions shaderInstructions;

    [Header("Ubicar las distintas luces de la scena")]
    public LightController luzAmbiente;
    public LightController luzBelly;

    [Header("Ubicar las caracteristicas de los espejos")]
    public GameObject realMirror;
    public MeshRenderer realMirrorRenderer;
    public Material realMirrorMaterial;
    public Material fakeMirrorMaterial;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        // Inicializamos el FlowManager en esta escena
        ChangeGameState(GameState.Chest);

        //Inicializamos componentes
        realMirrorRenderer = realMirror.GetComponent<MeshRenderer>();
    }

    private void Update() {
        // Solo tomamos inputs si no se esta ejecutando ninguna instruccion
        if (shaderInstructions.soundController.GetIsPlaying() == false) {
            // Si alguno de los inputs se mueve
            if (FlowManager.instance.CurrentState == GameState.Chest) {
                if (RvInputs.chest_Calibrated == 2) {
                    ChestInput(true);
                }
                else {
                    ChestInput(false);
                }
            }
            if (FlowManager.instance.CurrentState == GameState.Belly) {
                if (RvInputs.belly_Calibrated == 2) {
                    BellyInput(true);
                }
                else {
                    BellyInput(false);
                }
            }
        }
    }

    /// <summary>
    /// Un handler directo en esta scena para el FlowManager
    /// </summary>
    private void ChangeGameState(GameState gameState) {
        FlowManager.instance.SetState(gameState);
    }

    /// <summary>
    /// Llama al metodo del mismo nombre en la clase ShaderInstructions, funciona como proxy previniendo de que 
    /// haya instrucciones que sean llamadas, pero no deban ejecutarse
    /// </summary>
    public void ExecuteInstruction(Sn_02_Instructions_Steps_enum toExecuteInstruction) {

        if (CheckInstruction(toExecuteInstruction)
            && shaderInstructions.soundController.GetIsPlaying() == false){
            shaderInstructions.ExecuteInstruction(toExecuteInstruction); // Enviamos para ejecutarse
            WhenExecuteInstructions(toExecuteInstruction); // Hacemos cambios en la escena a partir de esta instruccion
        }
    }

    /// <summary>
    /// Apoya al metodo execute instruction
    /// </summary>
    private bool CheckInstruction(Sn_02_Instructions_Steps_enum toExecuteInstruction) {
        if ((int)shaderInstructions.lastInstructionExecuted + 1 == (int)toExecuteInstruction) {
            return true;
        }
        else {
            return false;
        }
    }

    /// <summary>
    /// Cosas que deberian pasar cuando se va a ejecutar una instruccion (En relacion a la escena)
    /// </summary>
    private void WhenExecuteInstructions(Sn_02_Instructions_Steps_enum toExecuteInstruction) {
        switch (toExecuteInstruction) {
            case Sn_02_Instructions_Steps_enum.Instruction_00:
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_01:// Activamos el ScriptSceneCollider
                GameManager.instance.cinturaCollider.enabled = true;
                ActiveRealMirror();
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_02:
                luzAmbiente.LightUp(); // Encendemos LuzAmbiente
                GameManager.instance.colliderGuia.AgrandarCollider(); // Agrandamos el collider Guia
                Debug.Log("LUZAMB+COLLIDER1");
                GameManager.instance.physicsPointer.gameObject.SetActive(true); // Se activa el RayCast del casco
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_03:
                GameManager.instance.luzGuia.LightUp(); // Encendemos LuzGuia
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_04:
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_05:          
                ChangeGameState(GameState.Belly); // Hacemos el cambio de estado a Belly
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_06:
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_07:
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_08:
                break;

            case Sn_02_Instructions_Steps_enum.Instruction_09:               
                SteamVR_LoadLevel.Begin("03_ForestNEW");// Vamos a ver que hace eso, teoricamente cambia la escena
                break;


        }
    }


    /// <summary>
    /// Handler desencadenado cada vez que hay un input de Chest
    /// </summary>
    public void ChestInput(bool input) {
        if (input) {
            ShaderController.instance.ShaderUp();         
            NPDSensor.instance.SoundUp();
            GameManager.instance.luzManoIzquierda.LightUp();
            GameManager.instance.luzManoDerecha.LightUp();
        }
        else {
            ShaderController.instance.ShaderDown();
            NPDSensor.instance.SoundDown();
        }
    }

    /// <summary>
    /// Handler desencadenado cada vez que hay un input de la panza
    /// </summary>
    public void BellyInput(bool input) {
        if (input) {

            // Prendemos la luz del belly
            luzBelly.LightUp();

            // El input del belly controla estas dos instrucciones, no obstante dada la proteccion que tiene
            // el metodo de ejecucion de instrucciones, jamas van a ejecutarse si no es el momento apropiado
            ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_06);
            ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_07);
            ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_08);
            ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_09);

        }
        else {
            // En caso contrario la apagamos
            luzBelly.LightDown();
        }
    }

    public void SetShaderStep(ShaderSteps newShaderStep) {
        actualShaderStep = newShaderStep;
        CheckActionsForShaderSteps();
    }

    private void CheckActionsForShaderSteps() {
        switch (actualShaderStep) {
            case ShaderSteps.None:
                return;
            case ShaderSteps.Hands:
                ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_01);
                return;
            case ShaderSteps.Mirror:
                ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_02);
                return;
            case ShaderSteps.Guia:
                ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_03);
                return;
            case ShaderSteps.Collider:

                return;
        }
    }

    /// <summary>
    /// Activa el espejo verdadero
    /// </summary>
    public void ActiveRealMirror() {
        realMirror.SetActive(true);
    }

    /// <summary>
    /// Cambia el material del espejo verdadero por el del falso
    /// </summary>
    public void ChangeMirrorMaterial() {
        realMirrorRenderer.material = fakeMirrorMaterial;
    }
}
