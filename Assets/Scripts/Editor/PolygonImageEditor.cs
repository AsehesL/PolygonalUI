using UnityEngine;
using UnityEditor.UI;
using UnityEditor;
using UnityEditor.UI;
using System.Collections;

[CustomEditor(typeof(PolygonImage))]
[CanEditMultipleObjects]
public class PolygonImageEditor : GraphicEditor
{

    private SerializedProperty m_Texture;
    private SerializedProperty m_EdgeWeights;

    protected override void OnEnable()
    {
        base.OnEnable();
        m_Texture = serializedObject.FindProperty("m_Texture");
        m_EdgeWeights = serializedObject.FindProperty("edgeWeights");
    }

    protected override void OnDisable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(m_Texture);
        EditorGUILayout.PropertyField(m_Color);
        EditorGUILayout.PropertyField(m_Material);
        EditorGUILayout.PropertyField(m_RaycastTarget);
        EditorGUILayout.PropertyField(m_EdgeWeights);

        serializedObject.ApplyModifiedProperties();
    }
}
