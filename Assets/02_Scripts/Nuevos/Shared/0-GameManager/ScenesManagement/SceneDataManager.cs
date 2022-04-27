using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataManager : MonoBehaviour
{
    public apagarSphereR spherefootR;
    public apagarSphereL spherefootL;
    public apagarCubeG cubeG;
    public ActiveSphereCollider sphereGuia;

    [Header("Indicar escena de inicio")]
    public SceneEnum startScene;

    public static SceneDataManager instance;

    // Se setea siempre antes de cambiar la escena desde la clase SceneLoadController
    // Tiene métodos Get y Set
    [HideInInspector]
    public SceneEnum actualScene;

    private void Awake() {
        if (instance == null) {
            instance = this;
            actualScene = startScene;
        }
    }

    private void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded; // Acoplamos el delegado para cuando se termine de cargar una escena
    }

    public void SetActualScene(SceneEnum newScene) {
        actualScene = newScene;
    }
    public SceneEnum GetActualScene() {
        return actualScene;
    }

    /// <summary>
    /// Se ejecutará siempre que se cargue una escena
    /// </summary>
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

        // Cuando pasamos a una escena en particular
        switch (actualScene) {
            case SceneEnum._00_Calibration:
                break;
            case SceneEnum._01_City:
                ActivarBody.instance.Apagar(); // Apagamos el cuerpo
                spherefootL.apagarfoot();
                spherefootR.apagarfoot();
                cubeG.apagarguia();
                sphereGuia.apagarsphereG();
                break;

            case SceneEnum._02_Shader:             
                spherefootL.apagarfoot();
                spherefootR.apagarfoot();
                cubeG.apagarguia();
                sphereGuia.apagarsphereG();
                break;

            case SceneEnum._03_Forest:
                break;
        }

    }

}
