using UnityEditor;

[CustomEditor(typeof(LightController))]
public class LightControllerEditor : Editor
{
    LightController lightController;

    SerializedProperty useIntensity;
    SerializedProperty useRange;

    SerializedProperty maxIntensity;
    SerializedProperty minIntensity;

    SerializedProperty dropIntensityOnAwake;

    SerializedProperty minRange;
    SerializedProperty maxRange;

    SerializedProperty softIntensityTransition;
    SerializedProperty softRangeTransition;

    SerializedProperty intensityTransitionTime;
    SerializedProperty rangeTransitionTime;

    SerializedProperty useKeyInputs;
    SerializedProperty lightUpKey;
    SerializedProperty lightDownKey;

    private void OnEnable() {

        lightController = (LightController)target;

        useIntensity = serializedObject.FindProperty("useIntensity");
        useRange = serializedObject.FindProperty("useRange");

        maxIntensity = serializedObject.FindProperty("maxIntensity");
        minIntensity = serializedObject.FindProperty("minIntensity");

        dropIntensityOnAwake = serializedObject.FindProperty("dropIntensityOnAwake");

        minRange = serializedObject.FindProperty("minRange");
        maxRange = serializedObject.FindProperty("maxRange");

        softIntensityTransition = serializedObject.FindProperty("softIntensityTransition");
        softRangeTransition = serializedObject.FindProperty("softRangeTransition");

        intensityTransitionTime = serializedObject.FindProperty("intensityTransitionTime");
        rangeTransitionTime = serializedObject.FindProperty("rangeTransitionTime");

        useKeyInputs = serializedObject.FindProperty("useKeyInputs");
        lightUpKey = serializedObject.FindProperty("lightUpKey");
        lightDownKey = serializedObject.FindProperty("lightDownKey");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        if (lightController.useRange || lightController.useIntensity) {
            EditorGUILayout.PropertyField(useKeyInputs);
            if (lightController.useKeyInputs) {
                EditorGUILayout.PropertyField(lightUpKey);
                EditorGUILayout.PropertyField(lightDownKey);
            }
        }

        EditorGUILayout.PropertyField(useIntensity);
        EditorGUILayout.PropertyField(useRange);

        if (lightController.useIntensity) {

            EditorGUILayout.PropertyField(maxIntensity);
            EditorGUILayout.PropertyField(minIntensity);

            EditorGUILayout.PropertyField(dropIntensityOnAwake);

            EditorGUILayout.PropertyField(softIntensityTransition);
            if (lightController.softIntensityTransition) {
                EditorGUILayout.PropertyField(intensityTransitionTime);
            }

        }
        if (lightController.useRange) {
            EditorGUILayout.LabelField("Indicar rangos", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(maxRange);
            EditorGUILayout.PropertyField(minRange);


            EditorGUILayout.PropertyField(softRangeTransition);
            if (lightController.softRangeTransition) {
                EditorGUILayout.PropertyField(rangeTransitionTime);
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}
