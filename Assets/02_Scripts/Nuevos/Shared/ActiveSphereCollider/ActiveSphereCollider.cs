using UnityEngine;
using UnityEngine.Events;



public class ActiveSphereCollider : MonoBehaviour, IUseInputs
{
    public MeshRenderer guiaMesh;

    [Header("Adjuntar manualmente o ponerlo en un objeto que contenga un SphereCollider")]
    public SphereCollider sphCol;

    [Header("Determinar que input va a ser utilizado activar el método agrandar de este collider")]
    public InputsKeyEnum keyListen;

    [Header("El radio de destino del collider cuando se ejecute una tecla")]
    public float destineRadius;

    private void Awake() {
        guiaMesh = GetComponent<MeshRenderer>();
        guiaMesh.enabled = true;

        if (sphCol == null) {
            sphCol = GetComponent<SphereCollider>();
        }
            sphCol.enabled = false;
            sphCol.radius = 0;

        if (keyListen != InputsKeyEnum.none) {
            AddInputListeners();
        }

    }

    private void OnDestroy() {
        if (keyListen != InputsKeyEnum.none) {
            RemoveInputListeners();
        }
    }

    public void AddInputListeners() {
        Inputs.instance.AddInputCheckFromEnum(keyListen, AgrandarCollider);
    }
    public void RemoveInputListeners() {
        Inputs.instance.RemoveInputCheckFromEnum(keyListen,AgrandarCollider);
    }

    public void AgrandarCollider() {
        sphCol.enabled = true;
        sphCol.radius = 1f;
    }

    public void apagarsphereG()
    {
        guiaMesh.enabled = false;
    }

}
