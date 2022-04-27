using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;
using Valve.VR;

public enum SceneEnum
{
    _00_Calibration,
    _01_City,
    _02_Shader,
    _03_Forest
}

public class SceneLoadController : MonoBehaviour, IUseInputs
{
    /// <summary>
    /// Clase que contiene datos de la escena
    /// </summary>

    [Header("Tiempo entre que se llama la escena y se carga")]
    public float trasitionTime;

    [Header("Bloquea el cambio de escenas si ya se está ejecutando")]
    private bool sceneIntransition;

    [Serializable]
    public class SceneData
    {
        public SceneEnum sceneEnum;
        public int buildIndex;
        public string sceneName;
        [Range(0, 60)] public float secondsOfFade; 

        public SceneData(SceneEnum cSceneEnum, string cSceneName, int cBuildIndex) {
            sceneEnum = cSceneEnum;
            sceneName = cSceneName;
            buildIndex = cBuildIndex;
        }
    }

    [Header(" Adjuntar los datos de todas las escenas que haya en el juego")]
    public SceneData[] sceneData;

    // Instancia estática de esta clase
    public static SceneLoadController instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        AddInputListeners();
    }

    private void OnDestroy() {
        RemoveInputListeners();
    }

    private void OnLevelWasLoaded(int level) {
        sceneIntransition = false;
    }

    // Interfaz IUseInputs
    public void AddInputListeners() {
        AllKeyInputs.space.AddListener(ChangeSceneForInput);
    }
    public void RemoveInputListeners() {
        AllKeyInputs.space.RemoveListener(ChangeSceneForInput);
    }



    /// <summary>
    /// Si se toca el input, entonces se cambia a la siguiente escena.
    /// </summary>
    private void ChangeSceneForInput() {
        SceneEnum actualScene = SceneDataManager.instance.GetActualScene();

        switch (actualScene) {
            case SceneEnum._00_Calibration:
                SceneChange(SceneEnum._01_City);
                break;
            case SceneEnum._01_City:
                SceneChange(SceneEnum._02_Shader);
                break;
            case SceneEnum._02_Shader:
                SceneChange(SceneEnum._03_Forest);
                break;
            case SceneEnum._03_Forest:
                SceneChange(SceneEnum._00_Calibration);
                break;
        }
    }

    /// <summary>
    /// Para cambiar de escena por indice
    /// </summary>
    public void SceneChange(int sceneIndex) {

        // Seteamos cuál será la escena en la que estaremos
        foreach (SceneData sd in sceneData) {
            if (sd.buildIndex == sceneIndex) {
                SetScene(sd.sceneEnum);
            }
        }
        SceneManager.LoadScene(sceneIndex); // Cargamos la escena

    }

    /// <summary>
    /// Para cambiar de escena por nombre
    /// </summary>
    public void SceneChange(string sceneName) {

        // Seteamos cuál será la escena en la que estaremos
        foreach (SceneData sd in sceneData) {
            if (sd.sceneName == sceneName) {
                SetScene(sd.sceneEnum);
            }
        }
        SceneManager.LoadScene(sceneName); // Cargamos la escena
    }

    /// <summary>
    /// Para cambiar de escena por enumeracion
    /// </summary>
    public void SceneChange(SceneEnum sceneEnum) {
        if (!sceneIntransition) {
            FadeOutVr();
            SetScene(sceneEnum);// Seteamos cuál será la escena en la que estaremos
            SceneManager.LoadScene(ReturnSceneIndexForEnum(sceneEnum));// Cargamos la escena
            sceneIntransition = true;
        }
    }

    private void SetScene(SceneEnum newScene) {
        SceneDataManager.instance.SetActualScene(newScene);
    }

    public int ReturnSceneIndexForEnum(SceneEnum sceneEnum) {
        foreach (SceneData data in sceneData) {
            if (data.sceneEnum == sceneEnum) {
                return data.buildIndex;
            }
        }
        Debug.LogError("No se encuentra cargada la escena en el arreglo SceneData");
        return -1;
    }

    public string ReturnSceneNameForEnum(SceneEnum sceneEnum) {
        foreach (SceneData data in sceneData) {
            if (data.sceneEnum == sceneEnum) {
                return data.sceneName;
            }
        }
        Debug.LogError("No se encuentra cargada la escena en el arreglo SceneData");
        return null;
    }

    /// <summary>
    /// Llama al método Begin de SteamVR_LoadLevel
    /// </summary>
    private void FadeOutVr() {
        SceneEnum actualScene = SceneDataManager.instance.actualScene;
        StartCoroutine(FadeIn(2));
        
    }

    IEnumerator FadeIn(float waitSeconds) {
        float half = waitSeconds / 2;
        SteamVR_Fade.View(Color.black, half);
        yield return new WaitForSeconds(half);
        SteamVR_Fade.View(Color.clear, half);

    }


}
