using UnityEngine;

public class PhysicsPointer : Pointer
{
    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRayCast();
        Vector3 endPosition = DefaultEnd(defaultLength);

        if (hit.collider && !SoundManagerGuia.instance.IsPlaying) //?????
        {
            endPosition = hit.point;//hit cualquier collider!!!
            print("HIT");
            //SoundManagerGuia.instance.PlayInstruccion04();

            //colliderOn.agrandarCollider();////agrando GUIA
            //alCollider = true;////////aviso al collider que se puede activar recien aca

        }
            
        return endPosition;
    }

    private RaycastHit CreateForwardRayCast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }

}
