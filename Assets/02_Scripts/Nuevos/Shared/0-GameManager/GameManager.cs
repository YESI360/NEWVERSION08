using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Adjuntar log GO de las esferas del cuerpo")]
    public GameObject handRBlue;
    public GameObject handLRed;
    public GameObject footR;
    public GameObject footL;

    [Header("Adjuntar el GO Guia")]
    public GameObject guia;

    [Header("Adjunar Cintura GO")]
    public GameObject cintura;
    public NewCinturaCollider cinturaCollider;

    [Header("Adjuntar las distintas luces")]
    public LightController luzManoIzquierda;
    public LightController luzManoDerecha;
    public LightController luzGuia;

    [Header("Ubicar los distintos colliders")]
    public ActiveSphereCollider colliderGuia;
    public ActiveSphereCollider colliderManoIzquierda;
    public ActiveSphereCollider colliderManoDerecha;

    [Header("PhysicPointer, ubicado en CameraVR en el GO CameraRig")]
    public NewPhysicstPointer physicsPointer;

    [Header("Cubo de calibracion")]
    public GameObject calibrationCube;


    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        colliderManoDerecha.sphCol.enabled = true;
        colliderManoIzquierda.sphCol.enabled = true;
    }

    private void Start() {
        guia.SetActive(false);
        physicsPointer.gameObject.SetActive(false);
    }

    private void OnLevelWasLoaded(int level) {

        switch (SceneDataManager.instance.actualScene) {
            case SceneEnum._01_City:
                _01_City_Handler();
                break;
            case SceneEnum._02_Shader:
                _02_Shader_Handler();
                break;
            case SceneEnum._03_Forest:
                _03_Forest_Handler();
                break;
        }
    }

    /// <summary>
    /// Maneja los valores del GM en caso de que la escena actual sea City
    /// </summary>
    private void _01_City_Handler() {
        handRBlue.SetActive(false);
        handLRed.SetActive(false);
        footR.SetActive(false);
        footL.SetActive(false);

        cinturaCollider.enabled = false; // Debe volver a activarse en el ShaderManager, al gatillar la instruccion 2
        cintura.SetActive(false);

        calibrationCube.SetActive(false);
    }

    /// <summary>
    /// Maneja los valores del GM en caso de que la escena actual sea Shader
    /// </summary>
    private void _02_Shader_Handler() {
        handRBlue.SetActive(true);
        handLRed.SetActive(true);
        handRBlue.GetComponent<Renderer>().enabled = false;
        handLRed.GetComponent<Renderer>().enabled = false;
        footR.SetActive(true);
        footL.SetActive(true);

        cintura.SetActive(true);
        guia.SetActive(true);
        colliderGuia.enabled = true;
        physicsPointer.gameObject.SetActive(true);
    }

    /// <summary>
    /// Maneja los valores del GM en caso de que la escena actual sea Forest
    /// </summary>
    private void _03_Forest_Handler() {
    
    }
}
