using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class NewCinturaCollider : MonoBehaviour
{
    private bool guia;
    private bool hands1;//= true;
    private bool hands2;// = true;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.black;

    private MeshRenderer meshRenderer;
    public bool handTouching;

    Coroutine CheckingWaistSeconds;

    public UnityEvent OnWaitsTouching;

    private void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();//salvavidas
    }

    private void OnTriggerEnter(Collider other) {
        handTouching = true;
        CheckCollision(other, true); // Primero checkeamos los tags de los trigger
        CheckingWaistSeconds = StartCoroutine(CheckHandsWithTime(3, other));
    }

    private void OnTriggerExit(Collider other) {
        CheckCollision(other, false);

        handTouching = false;

        // Cambia de color al sacar las manos
        meshRenderer.enabled = false;
        meshRenderer.material.color = normalColor;
    }

    /// <summary>
    /// Iniciamos el checkeo para ver si la cintura esta siendo tocada por ambas manos
    /// </summary>
    private IEnumerator CheckHandsWithTime(float secondsToWait, Collider other) {
        yield return new WaitForSeconds(secondsToWait);

        // Si no saca ninguna mano
        if (handTouching) {
            EnableWaistTouch(other);
        }
    }


    public void CheckCollision(Collider other, bool colliderEnter) {

        //handRed toca cintura
        if (other.gameObject.tag == "hands1") {
            hands1 = colliderEnter;
        }
        //handBlue toca cintura 
        else if (other.gameObject.tag == "hands2") {
            hands2 = colliderEnter;
        }
        // guia toca cintura
        else if (other.gameObject.tag == "objGuia") {
            guia = colliderEnter;
        }
    }

    /// <summary>
    /// Activamos el toque de la cintura
    /// </summary>
    public void EnableWaistTouch(Collider other) {

        // Si ambas manos estan en la cintura
        if (CheckHandsColliders()) {

            // Ver capsula solo para debug
            meshRenderer.enabled = true;
            meshRenderer.material.color = enterColor; //pinta SALVAVIDAS rojo

            // Si estamos en la escena shader, entonces
            if (SceneDataManager.instance.actualScene == SceneEnum._02_Shader) {
                ShaderManager.instance.ChangeMirrorMaterial();

                // Ejecutamos instruccion 5 (Solo se ejecutara si corresponde)
                ShaderManager.instance.ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_06);
            }

        }
    }

    /// <summary>
    /// Retorna true si ambas manos estan en la cintura
    /// </summary>
    private bool CheckHandsColliders() {
        if (hands1 && hands2) {
            return true;
        }
        else {
            return false;
        }
    }




}
