using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLooksAtGuia : MonoBehaviour, IPointerEnterHandler
{
    private MeshRenderer meshRenderer = null;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)//OnPointerStay NO FUNCIONA
    {
        GetComponent<MeshRenderer>().enabled = true;

        // Desencadena la llamada a la instruccion 4.
        Debug.Log("Attempt to call Shader Instruction 4");
        ShaderManager.instance.ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_04);

    }
}
