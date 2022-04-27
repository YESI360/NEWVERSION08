using UnityEngine;

/// <summary>
/// Destruye automáticamente el objeto cuando se inicia en la escena
/// </summary>
public class DestroyOnLoad : MonoBehaviour
{
    private void Awake() {
        Destroy(gameObject);
    }
}
