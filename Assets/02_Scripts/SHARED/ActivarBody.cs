using UnityEngine;

public class ActivarBody : MonoBehaviour, IUseInputs
{
    public static ActivarBody instance;

    Renderer rend;
    public float currentValue;
    private float TransparencyLevel;
    public float speed;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start()
    {
        currentValue = 0;
        TransparencyLevel = 0;
        rend = GetComponent<Renderer>();

        //Prender();
        //currentValue = rend.material.GetFloat("_Alpha");

        AddInputListeners(); // Adjuntamos los eventos de los inputs
    }

    private void OnDestroy() {
        RemoveInputListeners();
    }

    // Interfaz IUseInputs
    public void AddInputListeners() {
        AllKeyInputs.n.AddListener(Prender);
        AllKeyInputs.m.AddListener(Apagar);
    }
    public void RemoveInputListeners() {
        AllKeyInputs.n.RemoveListener(Prender);
        AllKeyInputs.m.RemoveListener(Apagar);
    }

    public void Prender()
    {
        rend.enabled = true;
        currentValue = rend.material.GetFloat("_Alpha");
        TransparencyLevel += Time.deltaTime * speed;
        rend.material.SetFloat("_Alpha", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));
    }

    public void Apagar() {
        rend.enabled = false;
    }

    public void ChangeAlpha()
    {
        rend.material.SetFloat("_Alpha", currentValue);
    }
}
