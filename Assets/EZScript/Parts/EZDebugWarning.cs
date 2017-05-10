using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EZDebugWarning : EZPart {
    public override EZType Type { get { return EZType.DebugWarning; } }
    public string Message = "";

    public override void Execute()
    {
        Debug.LogWarning(Message);
        base.Execute();
    }

    public override void EditorContent()
    {
        EditorGUILayout.LabelField(Type.ToString(), EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Message");
        Message = EditorGUILayout.TextArea(Message);
        EditorGUILayout.EndHorizontal();
        base.EditorContent();
    }
}
