public interface IUseInputs
{
    /// <summary>
    /// Deberá ser llamado al iniciar la clase
    /// </summary>
    void AddInputListeners();
    /// <summary>
    /// Deberá ser llamado cuando la clase se destruya
    /// </summary>
    void RemoveInputListeners();
}
