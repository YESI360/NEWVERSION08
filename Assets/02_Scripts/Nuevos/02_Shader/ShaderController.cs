using UnityEngine;
using UnityEngine.Events;


public class ShaderController : MonoBehaviour
{

    public static ShaderController instance;

    // Para referenciar el shader del material
    private Renderer renderer;

    // Variables que interactuan con el shader
    [HideInInspector] public float shaderCurrentValue;
    [Range(0, 100)] [Header("Indicar el porcentaje inicial del shader")] public float shaderStartValuePercent;
    [Range(0, 100)] [Header("Indicar el porcentaje para gatillar el paso \"Hands del shader\" ")] public float shaderHandsLimit;
    [Range(0, 100)] [Header("Indicar el porcentaje para gatillar el paso \"Mirror del shader\" ")] public float shaderMirrorLimit;
    [Range(0, 100)] [Header("Indicar el porcentaje para gatillar el paso \"Guia del shader\" ")] public float shaderGuiaLimit;


    [Range(1, 99)]
    [Header("Velocidad con la que sube y baja el shader cada frame")]
    public float shaderChangeSpeed;
    
    private float actualPercent;

    private float shaderMaxValue;
    private float shaderMinValue;



    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        renderer = GetComponent<Renderer>(); // Recuperamos el renderer
        renderer.material.SetFloat("_ZeroValue", shaderStartValuePercent / 100);
        shaderCurrentValue = shaderStartValuePercent / 100; // Inicializamos el valor
        shaderMinValue = shaderStartValuePercent / 100;
        shaderMaxValue = 1;
        shaderChangeSpeed /= 100; // Lo llevamos a un valor que vaya desde 0.01 a 1
        CalculeActualShaderPercent();
    }

    // Aca me quede el 04 04 22. tengo que ver de empezar a enganchar las instrucciones

    public void ShaderUp() {
        if (shaderCurrentValue < shaderMaxValue) {
            shaderCurrentValue += Random.Range(0.5f, 1.5f) * shaderChangeSpeed / 24;
            renderer.material.SetFloat("_ZeroValue", shaderCurrentValue);
            CalculeActualShaderPercent();
            CheckStepChange();
        }
    }

    public void ShaderDown() {
        if (shaderCurrentValue > shaderMinValue) {
            shaderCurrentValue -= Random.Range(0.1f, 0.3f) * shaderChangeSpeed / 72;
            renderer.material.SetFloat("_ZeroValue", shaderCurrentValue);
            CalculeActualShaderPercent();
        }
    }

    /// <summary>
    /// Simplemente nos da el porcentaje de llenado del Shader.
    /// </summary>
    private void CalculeActualShaderPercent() {
        actualPercent = shaderCurrentValue * 100;
    }

    /// <summary>
    /// Verificamos el estado del shader, y si supera una marca actualizamos el valor minimo
    /// e indicamos a la clase ShaderManager el cambio de estado
    /// </summary>
    private void CheckStepChange() {
        if (actualPercent > shaderHandsLimit && ShaderManager.instance.actualShaderStep == ShaderManager.ShaderSteps.None) {
            shaderMinValue = (shaderHandsLimit - shaderHandsLimit / 8) / 100;
            ShaderManager.instance.SetShaderStep(ShaderManager.ShaderSteps.Hands);
        }
        else if (actualPercent > shaderMirrorLimit && ShaderManager.instance.actualShaderStep == ShaderManager.ShaderSteps.Hands) {
            shaderMinValue = (shaderMirrorLimit - shaderMirrorLimit / 8) / 100;
            ShaderManager.instance.SetShaderStep(ShaderManager.ShaderSteps.Mirror);
        }
        else if (actualPercent > shaderGuiaLimit && ShaderManager.instance.actualShaderStep == ShaderManager.ShaderSteps.Mirror) {
            shaderMinValue = 1;
            ShaderManager.instance.SetShaderStep(ShaderManager.ShaderSteps.Guia);
        }
    }


}