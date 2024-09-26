using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Base), true)]
[CanEditMultipleObjects]
public class BaseInspector : Editor
{
    SerializedProperty priority;
    SerializedProperty moduleLevel;
    SerializedProperty module;
    SerializedProperty script;

    void OnEnable()
    {

        priority = serializedObject.FindProperty("priority");
        module = serializedObject.FindProperty("module");
        script = serializedObject.FindProperty("m_Script");
        moduleLevel = serializedObject.FindProperty("moduleLevel");
    }
    private static readonly string[] drawnProperties = new string[] { "m_Script", "module", "priority", "moduleLevel" };

    public override void OnInspectorGUI()
    {
        //EditorGUILayout.PropertyField(script);
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();

        EditorGUI.BeginDisabledGroup(!module.boolValue);
        EditorGUIUtility.labelWidth = 60;
        EditorGUILayout.PropertyField(moduleLevel, new GUIContent("Module"), GUILayout.Width(128));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.PropertyField(module, GUIContent.none, GUILayout.Width(24));

        EditorGUIUtility.labelWidth = 60;
        EditorGUILayout.PropertyField(priority, GUILayout.Width(128));


        EditorGUILayout.PropertyField(script, GUIContent.none);
        EditorGUIUtility.labelWidth = 0;

        EditorGUILayout.EndHorizontal();
        DrawPropertiesExcluding(serializedObject, drawnProperties);
        serializedObject.ApplyModifiedProperties();
    }

}
