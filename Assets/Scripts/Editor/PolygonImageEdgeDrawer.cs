using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditorInternal;

[CustomPropertyDrawer(typeof(PolygonImageEdge))]
public class PolygonImageEdgeDrawer : PropertyDrawer
{
    private ReorderableList m_ReorderableList;

    private void Init(SerializedProperty property)
    {
        if (m_ReorderableList == null)
        {
            m_ReorderableList = new ReorderableList(property.serializedObject,
                property.FindPropertyRelative("m_Weights"));
            m_ReorderableList.drawElementCallback = DrawEdgeWeight;
            m_ReorderableList.drawHeaderCallback = DrawHeader;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Init(property);
        var val = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        m_ReorderableList.DoList(position);
        EditorGUI.indentLevel = val;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        Init(property);

        return m_ReorderableList.GetHeight();
    }

    private void DrawEdgeWeight(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty itemData = m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
        EditorGUI.Slider(rect, itemData, 0, 1);
    }

    private void DrawHeader(Rect rect)
    {
        EditorGUI.LabelField(rect, "边权重");
    }
}
