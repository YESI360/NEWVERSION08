using UnityEngine;

public class GUILabels : MonoBehaviour
{
    private void OnGUI() {

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(5, 5, 100, 600), RvInputs.belly_Crude + "  " + "Belly " + RvInputs.belly_Calibrated);//calibracionCB 
        GUI.Label(new Rect(5, 30, 100, 600), RvInputs.chest_Crude + "  " + "Chest " + RvInputs.chest_Calibrated);//calibracionCC
    }
}
