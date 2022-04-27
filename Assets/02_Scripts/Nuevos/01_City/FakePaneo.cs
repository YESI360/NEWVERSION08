using UnityEngine;


/// <summary>
/// Este script represena un paneo. Son dos objetos que se acercan al player desde sus dos lados para simular
/// un efecto progresivo en el aumento del audio.
/// </summary>
[RequireComponent(typeof(SoundController))]
public class FakePaneo : MonoBehaviour
{
    [Header("Sound controller")]
    public SoundController soundController;

    [Header("Velocidad de desplazamiento hacia el personaje")]
    public float movementSpeed;

    [Header("El coeficiente de multiplicación de delta time por el cual se baja el volumen por frame")]
    public float speedVol;

    [Header("El destino de desplazamiento del objeto")]
    public Vector3 target;


    void Start() {
        soundController = GetComponent<SoundController>();
        soundController.SetVolume(1,0);
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }

    public void VolumenDown() {
        float actualVolume = soundController.GetVolume();
        soundController.SetVolume(actualVolume -= Time.deltaTime * speedVol,0);
    }
}
