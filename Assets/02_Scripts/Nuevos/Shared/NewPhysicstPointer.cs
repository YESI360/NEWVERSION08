using UnityEngine;
using System.Collections;

public class NewPhysicstPointer : Pointer
{
    [Header("Determinar los segundos que tienen que pasar tocando antes de que se ejecute la instruccion")]
    [Range(0,10)] public float waitSeconds;

    private LineRenderer lineRenderer = null;
    private bool onGuiaTouching;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update() {
        UpdateLength();
    }

    private void UpdateLength() {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd() {
        RaycastHit hit = CreateForwardRayCast();
        Vector3 endPosition = DefaultEnd(defaultLength);

        if (hit.collider) {
            if (hit.collider.CompareTag("objGuia")) {
                endPosition = hit.point;
                onGuiaTouching = true;
                print("Hit On Guia Object");
                ShaderManager.instance.ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_04);
            }
            else {
                onGuiaTouching = false;
            }
        }
        else {
            onGuiaTouching = false;
            Debug.Log("Other object touching");
        }

        return endPosition;
    }

    private RaycastHit CreateForwardRayCast() {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }

    private Vector3 DefaultEnd(float length) {
        return transform.position + (transform.forward * length);
    }

    private IEnumerator CheckTouching() {
        yield return new WaitForSeconds(waitSeconds);
        if (onGuiaTouching) {
            ShaderManager.instance.ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_03);
        }
    }

}
