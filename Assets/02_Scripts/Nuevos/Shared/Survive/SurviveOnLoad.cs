using UnityEngine;

/// <summary>
/// Nos permite mantener el script vivo tras las escenas
/// </summary>
public class SurviveOnLoad : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
