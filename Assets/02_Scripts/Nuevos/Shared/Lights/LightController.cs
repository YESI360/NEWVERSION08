using System.Collections;
using UnityEngine;

[ExecuteAlways]
public class LightController : MonoBehaviour, IUseInputs
{
    // Luz que vaa ser manejada
    [SerializeField] private Light myLight;

    [Header("Marcar para desplegar opciones")]
    public bool useIntensity;
    public bool useRange;

    [Header("Indicar intensidades")]
    public float maxIntensity;
    public float minIntensity;

    [Header("Marcar para inicializar la intensidad a 0 al aparecer")]
    public bool dropIntensityOnAwake;

    public float minRange;
    public float maxRange;

    [Header("Marcar si se quiere una transicion suave")]
    public bool softIntensityTransition;
    [Header("Marcar si se quiere una transicion suave")]
    public bool softRangeTransition;

    //Coroutinas para el funcionamiento suave de las luces
    Coroutine intensityUpCoroutine;
    Coroutine intensityDownCoroutine;
    Coroutine rangeUpCoroutine;
    Coroutine rangeDownCoroutine;

    [Header("Determinar el tiempo de la transición de intensidad (segundos)")]
    [Range(0, 3600f)] public float intensityTransitionTime;
    [Header("Determinar el tiempo de la transición de rango (segundos)")]
    [Range(0, 3600f)] public float rangeTransitionTime;

    [Header("Para saber si se usan inputs de teclado para regular esta luz ")]
    public bool useKeyInputs;

    [Header("Tecla para indicar el aumento del rango y/o intensidad")]
    public InputsKeyEnum lightUpKey;
    [Header("Tecla para indicar la disminución de rango y/o intensidad")]
    public InputsKeyEnum lightDownKey;

    private void Start() {
        myLight = GetComponent<Light>();
        if (Application.isPlaying) {
            if (useKeyInputs) {
                AddInputListeners();
                DropInAwake();
            }
        }
    }

    private void OnDestroy() {
        if (Application.isPlaying) {
            if (useKeyInputs) {
                RemoveInputListeners();
            }
        }
    }

    private void DropInAwake() {
        if (dropIntensityOnAwake) {
            myLight.intensity = 0;
        }
    }

    public void AddInputListeners() {
        Inputs.instance.AddInputCheckFromEnum(lightUpKey, LightUp);
        Inputs.instance.AddInputCheckFromEnum(lightDownKey, LightDown);
    }
    public void RemoveInputListeners() {
        Inputs.instance.RemoveInputCheckFromEnum(lightUpKey, LightUp);
        Inputs.instance.RemoveInputCheckFromEnum(lightDownKey, LightDown);
    }

    /// <summary>
    /// Sube la intensidad y/o rango de la luz 
    /// </summary>
    public void LightUp() {
        NullAllRoutines();
        if (useIntensity) {
            if (softIntensityTransition) {
                intensityUpCoroutine = StartCoroutine(SoftIntensity(maxIntensity));
            }
            else {
                myLight.intensity = maxIntensity;
            }
        }
        if (useRange) {
            if (softRangeTransition) {
                rangeUpCoroutine = StartCoroutine(SoftRange(maxRange));
            }
            else {
                myLight.range = maxRange;
            }
        }
    }

    /// <summary>
    /// Disminuye la intensidad y/o rango de la luz 
    /// </summary>
    public void LightDown() {
        NullAllRoutines();
        if (useIntensity) {
            if (softIntensityTransition) {
                intensityDownCoroutine = StartCoroutine(SoftIntensity(minIntensity));
            }
            else {
                myLight.intensity = minIntensity;
            }
        }
        if (useRange) {
            if (softRangeTransition) {
                rangeDownCoroutine = StartCoroutine(SoftRange(minRange));
            }
            else {
                myLight.range = minRange;
            }
        }
    }

    private void NullAllRoutines() {
        if (intensityUpCoroutine != null) { StopCoroutine(intensityUpCoroutine); }
        if (intensityDownCoroutine != null) { StopCoroutine(intensityDownCoroutine); }
        if (rangeUpCoroutine != null) { StopCoroutine(rangeUpCoroutine); }
        if (rangeDownCoroutine != null) { StopCoroutine(rangeDownCoroutine); }
        intensityUpCoroutine = null;
        intensityDownCoroutine = null;
        rangeUpCoroutine = null;
        rangeDownCoroutine = null;
    }

    private IEnumerator SoftIntensity(float intensityDestine) {
        float timeElapsed = 0;
        float distance = Mathf.Abs(myLight.intensity - intensityDestine);
        float distancePerCycle = (distance / intensityTransitionTime) / 10;
        Debug.Log("La distancia por ciclo será" + distancePerCycle);

        if (myLight.intensity > intensityDestine) { distancePerCycle *= -1; }

        while (true) {
            if (Mathf.Approximately(timeElapsed, intensityTransitionTime)) { break; }
            myLight.intensity += distancePerCycle;
            yield return new WaitForSeconds(0.1f);
            timeElapsed += 0.1f;
        }
        intensityUpCoroutine = null;
        intensityDownCoroutine = null;
    }

    private IEnumerator SoftRange(float rangeDestine) {

        float timeElapsed = 0;
        float distance = Mathf.Abs(rangeDestine - myLight.range);
        float distancePerCycle = (distance / intensityTransitionTime) / 10;

        if (myLight.range > rangeDestine) { distancePerCycle *= -1; }

        while (true) {
            if (Mathf.Approximately(timeElapsed, intensityTransitionTime)) { break; }
            myLight.range += distancePerCycle;
            yield return new WaitForSeconds(0.1f);
            timeElapsed += 0.1f;
        }
        rangeUpCoroutine = null;
        rangeDownCoroutine = null;
    }

}
